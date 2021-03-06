﻿using System.Collections.Generic;
using System.Text;
using LottieUWP.Animation;
using LottieUWP.Animation.Keyframe;

namespace LottieUWP.Model.Animatable
{
    internal abstract class BaseAnimatableValue<TV, TO> : IAnimatableValue<TV, TO>
    {
        internal readonly List<IKeyframe<TV>> Keyframes;
        protected readonly TV _initialValue;

        /// <summary>
        /// Create a default static animatable path.
        /// </summary>
        internal BaseAnimatableValue(TV initialValue) : this(new List<IKeyframe<TV>>(), initialValue)
        {
        }

        internal BaseAnimatableValue(List<IKeyframe<TV>> keyframes, TV initialValue)
        {
            Keyframes = keyframes;
            _initialValue = initialValue;
        }

        /// <summary>
        /// Convert the value type of the keyframe to the value type of the animation. Often, these
        /// are the same type.
        /// </summary>
        protected abstract TO ConvertType(TV value);

        public abstract IBaseKeyframeAnimation<TV, TO> CreateAnimation();

        public virtual bool HasAnimation()
        {
            return Keyframes.Count > 0;
        }

        public virtual TO InitialValue => ConvertType(_initialValue);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("parseInitialValue=").Append(_initialValue);
            if (Keyframes.Count > 0)
            {
                sb.Append(", values=").Append("[" + string.Join(",", Keyframes) + "]");
            }
            return sb.ToString();
        }
    }
}