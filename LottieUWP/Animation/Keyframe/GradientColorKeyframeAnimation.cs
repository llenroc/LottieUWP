﻿using System.Collections.Generic;
using Windows.UI;
using LottieUWP.Model.Content;

namespace LottieUWP.Animation.Keyframe
{
    internal class GradientColorKeyframeAnimation : KeyframeAnimation<GradientColor>
    {
        private readonly GradientColor _gradientColor;

        internal GradientColorKeyframeAnimation(List<IKeyframe<GradientColor>> keyframes) : base(keyframes)
        {
            var startValue = keyframes[0].StartValue;
            var size = startValue?.Size ?? 0;
            _gradientColor = new GradientColor(new float[size], new Color[size]);
        }

        public override GradientColor GetValue(IKeyframe<GradientColor> keyframe, float keyframeProgress)
        {
            _gradientColor.Lerp(keyframe.StartValue, keyframe.EndValue, keyframeProgress);
            return _gradientColor;
        }
    }
}