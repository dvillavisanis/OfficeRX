﻿using Ozeki.Media;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallCenter.Module.Win
{
    public class SoftPhone
    {
        ISoftPhone _softphone;                   // softphone object
        IPhoneLine _phoneLine;                   // phone line object
        IPhoneCall _call;                        // the call object
        Microphone _microphone;
        Speaker _speaker;
        MediaConnector _connector;               // connects the devices to each other (eg. microphone, speaker, mediaSender, mediaReceiver)
        PhoneCallAudioSender _mediaSender;       // after connected with the microphone, this will be attached to the call
        PhoneCallAudioReceiver _mediaReceiver;   // after connected with the speaker, this will be attached to the call
        public int lastError;
        public string lastErrorText;
        bool _incomingCall;  // indicates wheter we have an incoming call (so, the phone is ringing)

        #region Events

        public MediaHandlers MediaHandlers { get; private set; }
        /// <summary>
        /// Occurs when an incoming call received.
        /// </summary>
        public event EventHandler IncomingCall;

        /// <summary>
        /// Occurs when the registration state of the phone line has changed.
        /// </summary>
        public event EventHandler<RegistrationStateChangedArgs> PhoneLineStateChanged;

        /// <summary>
        /// Occurs when the state of the call has changed.
        /// </summary>
        public event EventHandler<CallStateChangedArgs> CallStateChanged;

        #endregion

        /// <summary>
        /// Default constructor, initalizes the softphone with deafult parameters.
        /// </summary>
        public SoftPhone()
        {


            //you can specify the User-Agent of the softphone
            string userAgent = "ORX SoftPhone";
            _softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000, userAgent);
            _microphone = Microphone.GetDefaultDevice();
            _speaker = Speaker.GetDefaultDevice();
            _connector = new MediaConnector();
            _mediaSender = new PhoneCallAudioSender();
            _mediaReceiver = new PhoneCallAudioReceiver();

            _incomingCall = false;

            MediaHandlers = new MediaHandlers();
            InitMedia();

        }

        /// <summary>
        /// Registers the SIP account to the PBX. 
        /// Calls cannot be made while the SIP account is not registered.
        /// If the SIP account requires no registration, the RegisterPhoneLine() must be called too to register the SIP account to the ISoftPhone.
        /// </summary>
        public void Register(bool registrationRequired, string displayName, string userName, string authenticationId, string registerPassword, string domainHost, int domainPort)
        {
            try
            {
                // We need to handle the event, when we have an incoming call.
                _softphone.IncomingCall += softphone_IncomingCall;

                // To register to a PBX, we need to create a SIP account
                var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);

                // With the SIP account and the NAT configuration, we can create a phoneline.
                _phoneLine = _softphone.CreatePhoneLine(account);


                // The phoneline has states, we need to handle the event, when it is being changed.
                _phoneLine.RegistrationStateChanged += phoneLine_PhoneLineStateChanged;

                // If our phoneline is created, we can register that.
                _softphone.RegisterPhoneLine(_phoneLine);


            }
            catch (Exception ex)
            {
                lastError = -100;
                lastErrorText = "Error during SIP registration: " + ex;

            }
        }
        public void InitMedia()
        {
            MediaHandlers.Init();
        }

        /// <summary>
        /// This will be called when the registration state of the phone line has changed.
        /// </summary>
        private void phoneLine_PhoneLineStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            DispatchAsync(() =>
            {
                var handler = PhoneLineStateChanged;
                if (handler != null)
                    handler(this, e);
            });
        }

        /// <summary>
        /// Starts the capturing and playing audio/video devices.
        /// Other devices can be used (and started), for example: WebCamera or WaveStreamPlayback.
        /// </summary>
        private void StartDevices()
        {
            InitMedia();

            if (_microphone != null)
            {
                _microphone.Start();
            }

            if (_speaker != null)
            {
                _speaker.Start();
            }




        }

        /// <summary>
        /// Stops the capturing and playing audio/video devices.
        /// Other devices can be stopped, for example: WebCamera.
        /// </summary>
        private void StopDevices()
        {
            if (_microphone != null)
            {
                _microphone.Stop();
            }

            if (_speaker != null)
            {
                _speaker.Stop();
            }
        }

        #region Media handling guide
        /*
         To send our voice through the microphone to the other client's speaker, we need to connect them.
         We send our voice through the mediaSender, and we get the other client's voice through the mediaSender to our speaker object. 
          
         To disconnect these handlers, we will use the DisconnectMedia() method.
		           
         It is possible to use other mediahandlers with the connector, for example we can connect a WaveStreamPlayback or an MP3StreamPlayback object to the MediaSender, so we can play music/voice
         during the call. For exmaple: when can create an IVR (Interactive Voice Response), we can create voice recorder etc.
         
         For example:
         We can connect an .mp3 file player (which plays an mp3 file into the voice call) by the "connector.Connect(Mp3StreamPlayback, mediaSender);  " line.
         (We should also create an MP3StreamPlayback object: "MP3StreamPlayback Mp3StreamPlayback; "
         and we need to tell to this object the details (what to play into the speaker, etc.))
         */
        #endregion

        /// <summary>
        /// Connects the audio handling devices to each other.
        /// The audio data will flow from the source to the destination.
        /// </summary>
        private void ConnectMedia()
        {
            InitMedia();
            if (_microphone != null)
            {
                _connector.Connect(_microphone, _mediaSender);
            }

            if (_speaker != null)
            {
                _connector.Connect(_mediaReceiver, _speaker);
            }
        }

        /// <summary>
        /// Disconnects the audio handling devices from each other.
        /// </summary>
        private void DisconnectMedia()
        {
            if (_microphone != null)
            {
                _connector.Disconnect(_microphone, _mediaSender);
            }

            if (_speaker != null)
            {
                _connector.Disconnect(_mediaReceiver, _speaker);
            }

            // You can close all of the connections by using: connector.Dispose();
        }

        /// <summary>
        /// Subscribes to the events of a call to receive notifications such as the state of the call has changed.
        /// In this sample subscribes only to the state changed and error occurred events.
        /// </summary>
        private void WireUpCallEvents()
        {
            _call.CallStateChanged += (call_CallStateChanged);
        }

        /// <summary>
        /// Unsubscribes from the events of a call.
        /// </summary>
        private void WireDownCallEvents()
        {
            _call.CallStateChanged -= (call_CallStateChanged);
        }

        /// <summary>
        /// This will be called when an incoming call received.
        /// To receive notifications from the call (eg. ringing), the program need to subscribe to the events of the call.
        /// </summary>
        private void softphone_IncomingCall(object sender, Ozeki.Media.VoIPEventArgs<IPhoneCall> e)
        {
            _call = e.Item;
            WireUpCallEvents();
            _incomingCall = true;

            DispatchAsync(() =>
            {
                var handler = IncomingCall;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            });
        }

        /// <summary>
        /// This will be called when the state of the call call has changed.
        /// </summary>
        /// <remarks>
        /// In this sample only three states will be handled: Answered, InCall, Ended
        /// 
        /// Answered: when the call has been answered, the audio devices will be started and attached to the call.
        /// It is required to comminicate with the other party and hear them.
        /// The devices are connected at softphone initialization time,
        /// so no need to connect them every time when a call is being answered.
        /// 
        /// InCall: when the call is in an active state, the audio deveices will be started.
        /// 
        /// Ended: when the call ends, the audio devices will be stopped and detached from the call.
        /// </remarks>
        private void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {



            // the call has been answered
            if (e.State == CallState.Answered)
            {
                StartDevices();
                MediaHandlers.StopRingback();
                _mediaReceiver.AttachToCall(_call);
                _mediaSender.AttachToCall(_call);

                // For further information about the calling of the ConnectMedia(), please check the implementation of this method.
                ConnectMedia();
            }

            if (e.State == CallState.Ringing)
            {
                StartDevices();
                MediaHandlers.StartRingback();

                //  MediaHandlers.AttachAudio(_call);
                //  MediaHandlers.AttachVideo(_call);

                _mediaReceiver.AttachToCall(_call);
                _mediaSender.AttachToCall(_call);

                // For further information about the calling of the ConnectMedia(), please check the implementation of this method.
                ConnectMedia();
            }
            if (e.State == CallState.RingingWithEarlyMedia)
            {

                MediaHandlers.StartRingback();
                //  MediaHandlers.AttachAudio(_call);
                //  MediaHandlers.AttachVideo(_call);
                // For further information about the calling of the ConnectMedia(), please check the implementation of this method.
                ConnectMedia();
            }

            // the call is in active communication state
            // IMPORTANT: this state can occur multiple times. for example when answering the call or the call has been taken off hold.
            if (e.State == CallState.InCall)
            {

                StartDevices();
                // MediaHandlers.StopRingback();

            }

            // the call has ended
            if (e.State.IsCallEnded())
            {
                if (_call != null)
                {
                    CallFinished();
                }
            }

            DispatchAsync(() =>
            {
                var handler = CallStateChanged;
                if (handler != null)
                    handler(this, e);
            });
        }
        public void TransferCall(string TransferTo)
        {
            if (_call != null)
            {
                _call.BlindTransfer(TransferTo);

            }



        }
        /// <summary>
        /// Starts calling the specified number.
        /// In this sample an outgoing call can be made if there is no current call (outgoing or incoming) on the phone line.
        /// </summary>
        public void StartCall(string numberToDial)
        {
            if (_call == null)
            {
                _call = _softphone.CreateCallObject(_phoneLine, numberToDial);
                WireUpCallEvents();

                // To make a call simply call the Start() method of the call object.
                _call.Start();
            }
        }

        /// <summary>
        /// Answers the current incoming call.
        /// </summary>
        public void AcceptCall()
        {
            // when the value of the incomingCall member is true, there is an incoming call
            if (_incomingCall)
            {
                _incomingCall = false;
                _call.Answer();
            }
        }

        /// <summary>
        /// Hangs up the current call.
        /// </summary>
        public void HangUp()
        {
            if (_call != null)
            {
                _call.HangUp();
                _call = null;
            }
        }

        /// <summary>
        /// If the call ends, we won't need our speaker and microphone anymore to communicate,
        /// until we enter into a call again, so we are calling the StopDevices() method.
        /// The mediaHandlers are getting detached from the call object
        /// (since we are not using our microphone and speaker, we have no media to send).
        /// We won't need the call's events anymore, becouse our call is about to be ended,
        /// and with setting the call to null, we are ending it.
        /// </summary>
        public void CallFinished()
        {
            StopDevices();

            _mediaReceiver.Detach();
            _mediaSender.Detach();
            DisconnectMedia();
            WireDownCallEvents();

            _call = null;
        }

        /// <summary>
        /// This method is used to solve the task blockings.
        /// </summary>
        private void DispatchAsync(Action action)
        {
            var task = new WaitCallback(o => action.Invoke());
            ThreadPool.QueueUserWorkItem(task);
        }
    }
}
