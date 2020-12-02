using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
    public static class VolumeParameterUtils
    {
        public static Dictionary<Type, Type> ParamToTypeDict = new Dictionary<Type, Type>()
        {
            {typeof(TextureCurveParameter), typeof(TextureCurve)},
            {typeof(BoolParameter), typeof(bool)},
            {typeof(LayerMaskParameter), typeof(int)},
            {typeof(IntParameter), typeof(int)},
            {typeof(NoInterpIntParameter), typeof(int)},
            {typeof(NoInterpMinIntParameter), typeof(int)},
            {typeof(NoInterpMaxIntParameter), typeof(int)},
            {typeof(ClampedIntParameter), typeof(int)},
            {typeof(MaxIntParameter), typeof(int)},
            {typeof(MinIntParameter), typeof(int)},
            {typeof(FloatParameter), typeof(float)},
            {typeof(FloatRangeParameter), typeof(float)},
            {typeof(ClampedFloatParameter), typeof(float)},
            {typeof(MaxFloatParameter), typeof(float)},
            {typeof(MinFloatParameter), typeof(float)},
            {typeof(NoInterpFloatParameter), typeof(float)},
            {typeof(NoInterpClampedFloatParameter), typeof(float)},
            {typeof(NoInterpFloatRangeParameter), typeof(float)},
            {typeof(NoInterpMaxFloatParameter), typeof(float)},
            {typeof(NoInterpMinFloatParameter), typeof(float)},
            {typeof(ColorParameter), typeof(Color)},
            {typeof(NoInterpColorParameter), typeof(Color)},
            {typeof(Vector2Parameter), typeof(Vector2)},
            {typeof(NoInterpVector2Parameter), typeof(Vector2)},
            {typeof(Vector3Parameter), typeof(Vector3)},
            {typeof(NoInterpVector3Parameter), typeof(Vector3)},
            {typeof(Vector4Parameter), typeof(Vector4)},
            {typeof(NoInterpVector4Parameter), typeof(Vector4)},
            {typeof(TextureParameter), typeof(Texture)},
            {typeof(NoInterpTextureParameter), typeof(Texture)},
            {typeof(RenderTextureParameter), typeof(RenderTexture)},
            {typeof(NoInterpRenderTextureParameter), typeof(RenderTexture)},
            {typeof(CubemapParameter), typeof(Cubemap)},
            {typeof(NoInterpCubemapParameter), typeof(Cubemap)},
            {typeof(AnimationCurveParameter), typeof(AnimationCurve)},
            {typeof(FogTypeParameter), typeof(FogType)},
            {typeof(FogColorParameter), typeof(FogColorMode)},
            {typeof(DiffusionProfileSettingsParameter), typeof(DiffusionProfileSettings)},
            {typeof(CascadePartitionSplitParameter), typeof(float)},
            {typeof(CascadeEndBorderParameter), typeof(float)},
            {typeof(BloomResolutionParameter), typeof(BloomResolution)},
            {typeof(DepthOfFieldModeParameter), typeof(DepthOfFieldMode)},
            {typeof(DepthOfFieldResolutionParameter), typeof(DepthOfFieldResolution)},
            {typeof(ExposureModeParameter), typeof(ExposureMode)},
            {typeof(MeteringModeParameter), typeof(MeteringMode)},
            {typeof(LuminanceSourceParameter), typeof(LuminanceSource)},
            {typeof(AdaptationModeParameter), typeof(AdaptationMode)},
            {typeof(FilmGrainLookupParameter), typeof(FilmGrainLookup)},
            {typeof(TonemappingModeParameter), typeof(TonemappingMode)},
            {typeof(VignetteModeParameter), typeof(VignetteMode)},
            {typeof(RayTracingModeParameter), typeof(RayTracingMode)},
            {typeof(EnvUpdateParameter), typeof(EnvironmentUpdateMode)},
            {typeof(BackplateTypeParameter), typeof(BackplateType)},
            {typeof(SkyIntensityParameter), typeof(SkyIntensityMode)},
            {typeof(SkyAmbientModeParameter), typeof(SkyAmbientMode)},
        };
    }
}
