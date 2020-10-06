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

			// Assert
			Assert.AreEqual(256, container.GetHeader().GetWidth());
		}
	}
}