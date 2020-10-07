using System;
using System.IO;

namespace CSharp_PVR
{
	sealed public class PVRContainerV2
	{
		private readonly PVRHeaderV2 headerV2;
		private readonly byte[] textureData;

		public PVRHeaderV2 GetHeader()
		{
			return this.headerV2;
		}

		public PVRContainerV2(Stream inputStream)
		{
			this.headerV2 = new PVRHeaderV2(inputStream);
			uint howManyBytesToRead = this.headerV2.GetSurfaceSize();
			this.textureData = new byte[(int)howManyBytesToRead];
			int offset = 0;
			while (howManyBytesToRead > 0)
			{
				int readAmount = inputStream.Read(this.textureData, offset, (int)howManyBytesToRead);
				howManyBytesToRead -= (uint)readAmount;
				offset += readAmount;
			}
		}

		public PVRContainerV2(byte[] inputBytes)
		{
			if (inputBytes == null)
			{
				throw new NullReferenceException("inputBytes is null");
			}

			if (inputBytes.Length < PVRHeaderV2.validHeaderSizeInBytes)
			{
				throw new ArgumentException($"Not enough data, at least {PVRHeaderV2.validHeaderSizeInBytes} is needed, but only have {inputBytes.Length}");
			}

			this.headerV2 = new PVRHeaderV2(new MemoryStream(inputBytes));
		}
	}
}