using NUnit.Framework;
using System.IO;
using CSharp_PVR;

namespace tests
{
	public class ParseV3FileTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ReadAndParse4bppPvrtcPvrTest()
		{
			// Arrange
			byte[] inputBytes = File.ReadAllBytes("hotair.4bpp.pvr");

			// Act
			PVRContainerV3 pvr = new PVRContainerV3(inputBytes);
			PVRHeaderV3 header = pvr.GetHeader();
			PVRMetadataV3 metadata = pvr.GetMetadata();

			// Assert
			Assert.AreEqual(512, header.GetWidth());
			Assert.AreEqual(512, header.GetHeight());
			Assert.AreEqual(1, header.GetDepth());

			Assert.AreEqual(1, header.GetNumberOfSurfaces());
			Assert.AreEqual(1, header.GetNumberOfFaces());

			Assert.AreEqual(10, header.GetMipMapCount());
			Assert.AreEqual(15, header.GetMetadataSizeInBytes());

			Assert.AreEqual(1, metadata.GetElements().Length);
			Assert.AreEqual(MetadataTypeV3.LogicalOrientation, metadata.GetElements()[0].GetMetadataType());
		}
	}
}