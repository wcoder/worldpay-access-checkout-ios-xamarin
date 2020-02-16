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

        private Result(string value)
        {
            _value = value;
        }

        private Result(Exception exception)
        {
            _exception = exception;
        }

        public static Result Success(string value)
        {
            return new Result(value);
        }

        public static Result Failure(Exception exception)
        {
            return new Result(exception);
        }
    }
}