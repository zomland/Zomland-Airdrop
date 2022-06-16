
const config = {
    apiKey: "AIzaSyC22bw6yVGykYOjwokg4p4HpnpOoAUvBxs",
    authDomain: "unity-sandbox-59721.firebaseapp.com",
    projectId: "unity-sandbox-59721",
    storageBucket: "unity-sandbox-59721.appspot.com",
    messagingSenderId: "813888386437",
    appId: "1:813888386437:web:f35f0f37698d2eb31bc0ec",
    measurementId: "G-7BDR5MR7W1"
};

const app = firebase.initializeApp(config);
const ui = new firebaseui.auth.AuthUI(firebase.auth());
const authContainer = document.getElementById('firebaseui-auth-container');

firebase.auth().onAuthStateChanged(function(user) {
    if (!user) {
        authContainer.style.display = 'flex';
        ui.start('#firebaseui-auth-container', {
            signInFlow: 'popup',
            // signInSuccessUrl: 'http://localhost:50121/',
            signInOptions: [
                firebase.auth.EmailAuthProvider.PROVIDER_ID,
                firebase.auth.GoogleAuthProvider.PROVIDER_ID
            ],
            tosUrl: 'https://google.com',
            privacyPolicyUrl: 'https://google.com'
        });
        unityInstance.SendMessage('Canvas', 'OnLoggedOut');
    } else {
        authContainer.style.display = 'none';
        console.log('FIREBASE AUTH:', user);
        unityInstance.SendMessage('Canvas', 'OnLoggedIn');
    }
});