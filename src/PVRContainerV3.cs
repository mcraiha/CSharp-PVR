using System;
using System.IO;

namespace CSharp_PVR
{
	sealed public class PVRContainerV3
	{
		private readonly PVRHeaderV3 headerV3;
		private readonly PVRMetadataV3 metadataV3;
		private readonly byte[] textureData;

		public PVRHeaderV3 GetHeader()
		{
			return this.headerV3;
		}

		public PVRContainerV3(Stream inputStream)
		{

		}

		public PVRContainerV3(byte[] inputBytes)
		{
			if (inputBytes == null)
			{
				throw new NullReferenceException("inputBytes is null");
			}

			if (inputBytes.Length < PVRHeaderV3.headerSizeInBytes)
			{
				throw new ArgumentException($"Not enough data, at least {PVRHeaderV3.headerSizeInBytes} is needed, but only have {inputBytes.Length}");
			}

			this.headerV3 = new PVRHeaderV3(inputBytes);

			this.metadataV3 = new PVRMetadataV3(inputBytes, 52, (int)this.headerV3.GetMetadataSizeInBytes());
		}
	}
}