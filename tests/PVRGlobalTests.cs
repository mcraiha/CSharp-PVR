using NUnit.Framework;
using System.IO;
using CSharp_PVR;

namespace tests
{
	public class PVRGlobalTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void DetectVersionTest()
		{
			// Arrange			

			// Act	

			// Assert
			using (FileStream fs = new FileStream("hotair.4bpp.pvr", FileMode.Open))
			{
				Assert.AreEqual(PvrVersion.Version3, PVRGlobal.DetectVersion(fs));
			}

			using (FileStream fs = new FileStream("256x256_opaque_rg_pvrtc_4bpp.pvr", FileMode.Open))
			{
				Assert.AreEqual(PvrVersion.Version2, PVRGlobal.DetectVersion(fs));
			}
		}

		[Test]
		public void IsV3FormatTest()
		{
			// Arrange			

			// Act	

			// Assert
			using (FileStream fs = new FileStream("hotair.4bpp.pvr", FileMode.Open))
			{
				Assert.IsTrue(PVRGlobal.IsV3Format(fs));
			}
		}

		[Test]
		public void IsV2FormatTest()
		{
			// Arrange			

			// Act	

			// Assert
			using (FileStream fs = new FileStream("256x256_opaque_rg_pvrtc_4bpp.pvr", FileMode.Open))
			{
				Assert.IsTrue(PVRGlobal.IsV2Format(fs));
			}
		}
	}
}