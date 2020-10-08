using System;
using System.IO;
using System.Collections;

namespace CSharp_PVR
{
	public enum MetadataTypeV3
	{
		Unknown = -1,
		AtlasLimits = 0,
		NormalMapInfo = 1,
		CubemapOrientation = 2,
		LogicalOrientation = 3,
		BorderSizes = 4,
		PaddingData = 5
	}

	sealed public class PVRMetadataElementV3
	{
		private static readonly byte[] onlyValidFourcc = new byte[] {  0x50, 0x56, 0x52, 0x33 };

		private readonly MetadataTypeV3 dataType;

		private readonly int sizeInBytes;

		private readonly byte[] dataAsByteArray;

		public PVRMetadataElementV3(Stream inputStream, bool leaveStreamOpen = true)
		{
			using (BinaryReader reader = new BinaryReader(inputStream, System.Text.Encoding.UTF8, leaveOpen: true))
			{
				byte[] fourCC = reader.ReadBytes(4);
				if (!StructuralComparisons.StructuralEqualityComparer.Equals(onlyValidFourcc, fourCC))
				{
					string invalidValueAsHex = String.Concat(Array.ConvertAll(fourCC, x => x.ToString("X2")));
					throw new ArgumentException($"Not valid FourCC for Metadata, invalid array is {invalidValueAsHex}");
				}

				uint keyAsUint = reader.ReadUInt32();
				uint dataSize = reader.ReadUInt32();
				this.dataAsByteArray = reader.ReadBytes((int)dataSize);
			}
		}

		public PVRMetadataElementV3(byte[] inputData)
		{

		}
	}
}