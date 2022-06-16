using System;
using System.Collections.Generic;

namespace FirebaseWebGL.Scripts.Objects
{
    [Serializable]
    public class FirebaseUser
    {
        public string displayName;
        
        public string email;
        
        public bool isAnonymous;
        
        public bool isEmailVerified;
        
        public FirebaseUserMetadata metadata;
        
        public string phoneNumber;
        
        public FirebaseUserProvider[] providerData;
        
        public string providerId;
        
        public string uid;
    }
    
    [Serializable]
    public class FirebaseProfile
    {
        public string email;
        public string family_name;
        public string given_name;
        public string granted_scopes;
        public string id;
        public string locale;
        public string name;
        public string picture;
        public bool verified_email;
    }
    
    [Serializable]
    public class FirebaseAdditionalUserInfo
    {
        public bool isNewUser;
        public FirebaseProfile profile;
        public string providerId;
    }
}