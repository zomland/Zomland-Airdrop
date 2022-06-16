mergeInto(LibraryManager.library, {

    CreateUserWithEmailAndPassword: function (email, password, objectName, callback, fallback) {
        var parsedEmail = Pointer_stringify(email);
        var parsedPassword = Pointer_stringify(password);
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedCallback = Pointer_stringify(callback);
        var parsedFallback = Pointer_stringify(fallback);

        try {

            firebase.auth().createUserWithEmailAndPassword(parsedEmail, parsedPassword).then(function (unused) {
                unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: signed up for " + parsedEmail);
            }).catch(function (error) {
                unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
            });

        } catch (error) {
            unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    SignInWithEmailAndPassword: function (email, password, objectName, callback, fallback) {
        var parsedEmail = Pointer_stringify(email);
        var parsedPassword = Pointer_stringify(password);
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedCallback = Pointer_stringify(callback);
        var parsedFallback = Pointer_stringify(fallback);

        try {

            firebase.auth().signInWithEmailAndPassword(parsedEmail, parsedPassword).then(function (unused) {
                unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: signed in for " + parsedEmail);
            }).catch(function (error) {
                unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
            });

        } catch (error) {
            unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    SignInWithGoogle: function (objectName, callback, fallback, additionalCallback) {
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedCallback = Pointer_stringify(callback);
        var parsedFallback = Pointer_stringify(fallback);
        var parsedAdditionalCallback = Pointer_stringify(additionalCallback);

        try {
            var provider = new firebase.auth.GoogleAuthProvider();
            firebase.auth().signInWithPopup(provider).then(function (result) {
                var user = result.user;
                var additional = result.additionalUserInfo;
                var firebaseUser = JSON.stringify(user);
                unityInstance.SendMessage(parsedObjectName, parsedAdditionalCallback, JSON.stringify(additional));
                unityInstance.SendMessage(parsedObjectName, parsedCallback, firebaseUser);
            }).catch(function (error) {
                unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
            });

        } catch (error) {
            unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    SignInWithFacebook: function (objectName, callback, fallback) {
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedCallback = Pointer_stringify(callback);
        var parsedFallback = Pointer_stringify(fallback);

        try {
            var provider = new firebase.auth.FacebookAuthProvider();
            firebase.auth().signInWithPopup(provider).then(function (unused) {
                unityInstance.SendMessage(parsedObjectName, parsedCallback, "Success: signed in with Facebook!");
            }).catch(function (error) {
                unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
            });

        } catch (error) {
            unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        }
    },

    OnAuthStateChanged: function (objectName, onUserSignedIn, onUserSignedOut) {
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedOnUserSignedIn = Pointer_stringify(onUserSignedIn);
        var parsedOnUserSignedOut = Pointer_stringify(onUserSignedOut);

        firebase.auth().onAuthStateChanged(function(user) {
            if (user) {
                unityInstance.SendMessage(parsedObjectName, parsedOnUserSignedIn, JSON.stringify(user));
            } else {
                unityInstance.SendMessage(parsedObjectName, parsedOnUserSignedOut, "User signed out");
            }
        });

    },
    
    SignOut: function(objectName, onSuccess, onFail) {
        var parsedObjectName = Pointer_stringify(objectName);
        var parsedCallback = Pointer_stringify(onSuccess);
        var parsedFallback = Pointer_stringify(onFail);
        firebase.auth().signOut().then(function() {
            // Sign-out successfully
            unityInstance.SendMessage(parsedObjectName, parsedCallback, "User Sign Out");
        }).catch(function(error) {
            // Sign-out failed
            unityInstance.SendMessage(parsedObjectName, parsedFallback, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        });
    },
});
