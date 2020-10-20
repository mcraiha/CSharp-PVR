using NUnit.Framework;
using System.IO;
using CSharp_PVR;

namespace tests
{
	public class ParseV2FileTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ReadAndParse4bppPvrtcPvrTest()
		{
			// Arrange
			FileStream fs = new FileStream("256x256_opaque_rg_pvrtc_4bpp.pvr", FileMode.Open);

			// Act
			PVRContainerV2 container = new PVRContainerV2(fs);

			fs.Close();

			PVRHeaderV2 header = container.GetHeader();

			// Assert
			Assert.AreEqual(256, header.GetWidth());
			Assert.AreEqual(256, header.GetHeight());
			Assert.AreEqual(0, header.GetMipMapCount());
			Assert.AreEqual(PixelFormatV2.PVRTC4_2, header.GetPixelFormat());
			Assert.IsFalse(header.AreMipMapsPresentFlag());
			Assert.AreEqual(32768, header.GetSurfaceSize());
			Assert.AreEqual(4, header.GetBitsPerPixel());
			Assert.AreEqual(0, header.GetRedChannelMaskAsUint());
			Assert.AreEqual(0, header.GetGreenChannelMaskAsUint());
			Assert.AreEqual(0, header.GetBlueChannelMaskAsUint());
			Assert.AreEqual(0, header.GetAlphaChannelMaskAsUint());
			Assert.AreEqual(0, header.GetNumberOfSurfaces());
		}
	}
}