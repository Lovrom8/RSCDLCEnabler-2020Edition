#include "KillGuitarVolumeEffect.hpp"

namespace CrowdControl::Effects {
	EffectResult KillGuitarVolumeEffect::Test(Request request)
	{
		std::cout << "KillGuitarVolumeEffect::Test()" << std::endl;

		if (!MemHelpers::IsInSong() || running)
			return EffectResult::Retry;

		return EffectResult::Success;
	}

	/// <summary>
	/// We can individually set volumes of the WWise objects the game uses
	/// The current volume is read by using Wwise_Sound_Query_GetRTPCValue_Char
	/// New volume is set using Wwise_Sound_Query_SetRTPCValue_Char, the game calls it with both 0xffffffff and 0x00001234 as object IDs 
	/// </summary>
	/// <returns> EffectResult::Retry if we aren't currently in a song or the same effect is running already, or EffectResult::Sucess if we are in a song</returns>
	EffectResult KillGuitarVolumeEffect::Start(Request request)
	{
		std::cout << "KillGuitarVolumeEffect::Start()" << std::endl;

		if (!MemHelpers::IsInSong() || running)
			return EffectResult::Retry;

		running = true;

		RTPCValue_type type = RTPCValue_GameObject; // Save old volume
		WwiseVariables::Wwise_Sound_Query_GetRTPCValue_Char("Mixer_Player1", 0xffffffff, &oldVolume, &type);

		WwiseVariables::Wwise_Sound_SetRTPCValue_Char("Mixer_Player1", 0.0f, 0xffffffff, 2000, AkCurveInterpolation_Linear);
		WwiseVariables::Wwise_Sound_SetRTPCValue_Char("Mixer_Player1", 0.0f, 0x00001234, 2000, AkCurveInterpolation_Linear);		
		
		SetDuration(request);
		endTime = std::chrono::steady_clock::now() + std::chrono::seconds(duration);

		return EffectResult::Success;
	}

	void KillGuitarVolumeEffect::Run()
	{
		// Stop automatically after duration has elapsed
		if (running) {
			auto now = std::chrono::steady_clock::now();
			std::chrono::duration<double> duration = (endTime - now);

			if (duration.count() <= 0) Stop();
		}
	}

	/// <summary>
	/// Restore the volume back to it's original values
	/// </summary>
	/// <returns> EffectResult::Success</returns>
	EffectResult KillGuitarVolumeEffect::Stop()
	{
		std::cout << "KillGuitarVolumeEffect::Stop()" << std::endl;

		running = false;

		WwiseVariables::Wwise_Sound_SetRTPCValue_Char("Mixer_Player1", oldVolume, 0xffffffff, 2000, AkCurveInterpolation_Linear);
		WwiseVariables::Wwise_Sound_SetRTPCValue_Char("Mixer_Player1", oldVolume, 0x00001234, 2000, AkCurveInterpolation_Linear);

		return EffectResult::Success;
	}
}