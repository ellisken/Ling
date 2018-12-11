/* Tutorial to get started with Recorder.js
 * https://addpipe.com/blog/using-recorder-js-to-capture-wav-audio-in-your-html5-web-site/
*/

/* Variables */

// Stream from getUserMedia()
let getUserMediaStream;
// Recorder.js object
let recording;
// MediaStreamAudioSourceNode we will be recording
let input;

// Shim for AudioContext when it's not audio video bridging. Shims allow for backwards compatibility by intercepting API calls and providing a layer of abstraction between a caller and a target.
let AudioContext = window.AudioContext || webkit.AudioContext;
// New audio context that helps us record
let audioContext = new AudioContext;
