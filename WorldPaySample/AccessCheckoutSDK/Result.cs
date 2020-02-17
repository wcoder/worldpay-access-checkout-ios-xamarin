//
// Result.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;

namespace AccessCheckoutSDK
{
    public class Result
    {
        private readonly Exception _exception;
        private readonly string _value;
        private readonly ResultStatus _status;

        private Result(string value)
        {
            _value = value;
            _status = ResultStatus.Success;
        }

        private Result(Exception exception)
        {
            _exception = exception;
            _status = ResultStatus.Failure;
        }

        public static Result Success(string value)
        {
            return new Result(value);
        }

        public static Result Failure(Exception exception)
        {
            return new Result(exception);
        }

        public string SuccessValue => _value;
        
        public Exception FailureValue => _exception;
        
        public static implicit operator ResultStatus(Result result) => result._status;
    }
    
    

    public enum ResultStatus
    {
        Success,
        Failure
    }
}