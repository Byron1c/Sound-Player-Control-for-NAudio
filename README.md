# Sound-Player-Control-for-NAudio
A simple user control for visual and programmatic playing of sounds

This control can be used by dragging and dropping it onto a form, or programattically.
Uses Dot NET 4.8


A very simple example
(Check the test code for more examples)


SoundPlayer sp;

private void btnPlaySound_Click(object sender, EventArgs e)
{
	...
	sp = new SoundPlayer(@"C:\Windows\Media\Alarm01.wav", 95);
	sp.PlaybackStopped += SoundPlayer_PlaybackStopped;
	sp.PlaySound();
	...
}


private void SoundPlayer_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
{
	MessageBox.Show("Programmatic sound has finished playing");
	sp.Dispose();
}
