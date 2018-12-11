/* Tutorial used to get started with Recorder.js
 * https://addpipe.com/blog/using-recorder-js-to-capture-wav-audio-in-your-html5-web-site/
*/

/* Variables */

// Stream from getUserMedia()
let getUserMediaStream;
// Recorder.js object
let rec;
// MediaStreamAudioSourceNode we will be recording
let input;

// Shim for AudioContext when it's not audio video bridging. Shims allow for backwards compatibility by intercepting API calls and providing a layer of abstraction between a caller and a target.
let AudioContext = window.AudioContext || webkit.AudioContext;
// New audio context that helps us record
let audioContext = new AudioContext;

// Grab DOM elements
const recordButton = document.getElementById("record-button");
const pauseButton = document.getElementById("pause-button");
const stopButton = document.getElementById("stop-button");

// Attach event listeners
recordButton.addEventListener("click", startRecording);
pauseButton.addEventListener("click", pauseRecording);
stopButton.addEventListener("click", stopRecording);

// Event handler to "Start" recording an audio clip
function startRecording() {
    console.log("start recording has been clicked!");

    // Disable the record button until getUserMedia() returns a success or fail
    recordButton.disabled = true;
    stopButton.disabled = false;
    pauseButton.disables = false;

    /*
      getUserMedia() is a promise-based method that prompts the user for permission to use a a media input, which produces a MediaStream object with a specified list of a/v tracks. In our case, the stream wil have an audio track.
        https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
    */

    // Set request permissions for only audio
    const constraints = { audio: true, video: false };

    navigator.mediaDevices.getUserMedia(constraints).then((stream) => {
        console.log("GUM success! i'm in the promise's callback!");

        // Assign our getUserMediaStream global variable to the recorded stream for later use
        getUserMediaStream = stream;

        // Use the stream
        input = audioContext.createMediaStreamSource(stream);

        // Create the Recorder object and configure it to record mono channel sound because dual channel will result in double the file size
        rec = new Recorder(input, { numChannels: 1 });

        // Begin recording
        rec.record();

        console.log("recording has started");
    }).catch((err) => {
        // Enable the "Record" button again if the recording fails
        recordButton.disabled = false;
        pauseButton.disabled = true;
        stopButton.disabled = true;
    });
}

// Event handler to "Pause" a recording
function pauseRecording() {
    console.log("pause hit on rec.recording =", rec.recording);

    if (rec.recording) {
        // Pause
        rec.stop();
        // Change UI text of "Pause" button to "Resume"
        pauseButton.innerHTML = "Resume";
    } else {
        // Resume
        rec.record();
        pauseButton.innerHTML = "Pause";
    }
}
