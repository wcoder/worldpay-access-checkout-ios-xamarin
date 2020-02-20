//
// Result.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2020 Yauheni Pakala
//

using System;

namespace AccessCheckoutSDK.Core
{
    public class Result
    {
        /// <summary>
        /// Always returns NULL. Please use <see cref="ResultExtensions"/> for continue.
        /// </summary>
        /// <typeparam name="TSuccess"></typeparam>
        /// <typeparam name="TFailure"></typeparam>
        /// <returns></returns>
        public static Result<TSuccess, TFailure> Null<TSuccess, TFailure>() where TFailure : Exception
        {
            return null;
        }
    }

    public class Result<TSuccess, TFailure> : Result where TFailure : Exception
    {
        private readonly TSuccess _success;
        private readonly TFailure _failure;
        private readonly ResultStatus _status;

        public Result(TSuccess success, TFailure failure, ResultStatus status)
        {
            _success = success;
            _failure = failure;
            _status = status;
        }

        public TSuccess Success => _success;
        public TFailure Failure => _failure;

        public static implicit operator ResultStatus(Result<TSuccess, TFailure> result) => result._status;

        public static implicit operator Exception(Result<TSuccess, TFailure> result) => result._failure;

        public static implicit operator TSuccess(Result<TSuccess, TFailure> result) => result._success;
    }


    public static class ResultExtensions
    {
        /// <summary>
        /// A success, storing a `Success` value.
        ///
        /// Returns new <see cref="Result{TSuccess, TFailure}"/> object.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="success"></param>
        /// <typeparam name="TSuccess"></typeparam>
        /// <typeparam name="TFailure"></typeparam>
        /// <returns></returns>
        public static Result<TSuccess, TFailure> Success<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> _, TSuccess success) where TFailure : Exception
        {
            return new Result<TSuccess, TFailure>(success, null, ResultStatus.Success);
        }

        /// <summary>
        /// A failure, storing a `Failure` value.
        ///
        /// Returns new <see cref="Result{TSuccess, TFailure}"/> object.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="failure"></param>
        /// <typeparam name="TSuccess"></typeparam>
        /// <typeparam name="TFailure"></typeparam>
        /// <returns></returns>
        public static Result<TSuccess, TFailure> Failure<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> _, TFailure failure) where TFailure : Exception
        {
            return new Result<TSuccess, TFailure>(default, failure, ResultStatus.Failure);
        }
    }

    public enum ResultStatus
    {
        Success,
        Failure
    }
}