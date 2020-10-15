using System;
using System.IO;
using System.Collections.Generic;

namespace CSharp_PVR
{
	sealed public class PVRContainerV3
	{
		private readonly PVRHeaderV3 headerV3;
		private readonly PVRMetadataV3 metadataV3;
		private readonly List<byte[]> textureData;

		public PVRHeaderV3 GetHeader()
		{
			return this.headerV3;
		}

		public PVRMetadataV3 GetMetadata()
		{
			return this.metadataV3;
		}

		public byte[] GetTextureData(int mipMapLevel = 0)
		{
			return this.textureData[mipMapLevel];
		}

		public PVRContainerV3(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new NullReferenceException("inputStream is null");
			}

			if (!inputStream.CanRead)
			{
				throw new ArgumentException("inputStream must be readable");
			}

			this.headerV3 = new PVRHeaderV3(inputStream);

			this.metadataV3 = new PVRMetadataV3(inputStream, (int)this.headerV3.GetMetadataSizeInBytes());

			this.textureData = new List<byte[]>();
			for (int i = 0; i < this.headerV3.GetMipMapCount(); i++)
			{
				int divisor = (int)Math.Pow(2, i);
				int currentWidth = (int)this.headerV3.GetWidth() / divisor;
				int currentHeight = (int)this.headerV3.GetHeight() / divisor;
				int bytesForThisLevel = PVRHeaderV3.CalculateBytesOfData(this.headerV3.GetPixelFormat(), currentWidth, currentHeight);
				byte[] byteArray = new byte[bytesForThisLevel];
				inputStream.Read(byteArray, 0, bytesForThisLevel);
				this.textureData.Add(byteArray);
			}
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

			this.textureData = new List<byte[]>();

			int currentPos = 52 + (int)this.headerV3.GetMetadataSizeInBytes();
			for (int i = 0; i < this.headerV3.GetMipMapCount(); i++)
			{
				int divisor = (int)Math.Pow(2, i);
				int currentWidth = (int)this.headerV3.GetWidth() / divisor;
				int currentHeight = (int)this.headerV3.GetHeight() / divisor;
				int bytesForThisLevel = PVRHeaderV3.CalculateBytesOfData(this.headerV3.GetPixelFormat(), currentWidth, currentHeight);
				byte[] byteArray = new byte[bytesForThisLevel];
				Buffer.BlockCopy(inputBytes, currentPos, byteArray, 0, bytesForThisLevel);
				this.textureData.Add(byteArray);
				currentPos += bytesForThisLevel;
			}
		}
	}
}