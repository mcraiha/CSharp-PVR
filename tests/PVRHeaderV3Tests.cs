using NUnit.Framework;
using System.IO;
using CSharp_PVR;

namespace tests
{
	public class PVRHeaderV3Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CalculateBytesOfDataTest()
		{
			// Arrange
			int width1 = 512;
			int height1 = 512;

			int width2 = 256;
			int height2 = 256;

			// Act
			int shouldBe128k = PVRHeaderV3.CalculateBytesOfData(PixelFormatV3.PVRTC4bppRGBA, width1, height1);
			int shouldBe64k = PVRHeaderV3.CalculateBytesOfData(PixelFormatV3.PVRTC2bppRGBA, width1, height1);

			int shouldBe32k = PVRHeaderV3.CalculateBytesOfData(PixelFormatV3.PVRTC4bppRGB, width2, height2);
			int shouldBe16k = PVRHeaderV3.CalculateBytesOfData(PixelFormatV3.PVRTC2bppRGB, width2, height2);

			// Assert
			Assert.AreEqual(131_072, shouldBe128k);
			Assert.AreEqual(65_536, shouldBe64k);

			Assert.AreEqual(32_768, shouldBe32k);
			Assert.AreEqual(16_384, shouldBe16k);
		}
	}
}