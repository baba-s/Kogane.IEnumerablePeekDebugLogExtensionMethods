using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane
{
    // ReSharper disable once InconsistentNaming
    public static class IEnumerablePeekDebugLogExtensionMethods
    {
        public delegate void LogDelegate( object item );

        public static LogDelegate OnLog        { get; set; } = item => Debug.Log( item );
        public static LogDelegate OnLogWarning { get; set; } = item => Debug.LogWarning( item );
        public static LogDelegate OnLogError   { get; set; } = item => Debug.LogError( item );

        public static IEnumerable<T> PeekDebugLog<T>( [NotNull] this IEnumerable<T> source )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLog?.Invoke( x );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekDebugLog<T>
        (
            [NotNull] this IEnumerable<T>  source,
            [NotNull]      Func<T, object> selector
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLog?.Invoke( selector( x ) );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekDebugLogWarning<T>( [NotNull] this IEnumerable<T> source )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLogWarning?.Invoke( x );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekDebugLogWarning<T>
        (
            [NotNull] this IEnumerable<T>  source,
            [NotNull]      Func<T, object> selector
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLogWarning?.Invoke( selector( x ) );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekDebugLogError<T>( [NotNull] this IEnumerable<T> source )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLogError.Invoke( x );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekDebugLogError<T>
        (
            [NotNull] this IEnumerable<T>  source,
            [NotNull]      Func<T, object> selector
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    OnLogError?.Invoke( selector( x ) );
                    yield return x;
                }
            }

            return Iterator();
        }
    }
}