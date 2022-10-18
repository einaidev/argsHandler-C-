using System;


namespace Errors {
    [Serializable]
    public class ExtensionError : Exception
    {
        public ExtensionError ()
        {}

        public ExtensionError (string message) 
            : base(message)
        {}

        public ExtensionError (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }

    public class WordlistFileDontExist : Exception
    {
        public WordlistFileDontExist ()
        {}

        public WordlistFileDontExist (string message) 
            : base(message)
        {}

        public WordlistFileDontExist (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }
    public class MissgingArgument : Exception
    {
        public MissgingArgument ()
        {}

        public MissgingArgument (string message) 
            : base(message)
        {}

        public MissgingArgument (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }
    public class InvalidArg : Exception
    {
        public InvalidArg ()
        {}

        public InvalidArg (string message) 
            : base(message)
        {}

        public InvalidArg (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }

    public class UrlError : Exception
    {
        public UrlError ()
        {}

        public UrlError (string message) 
            : base(message)
        {}

        public UrlError (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }
}