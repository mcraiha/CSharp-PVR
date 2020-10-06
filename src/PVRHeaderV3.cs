using System;
using System.IO;

namespace CSharp_PVR
{
	public enum TextureFlags : uint
	{
		/// <summary>
		/// No flags set
		/// </summary>
		NoFlag = 0,

		/// <summary>
		/// Colour values within the texture have been pre-multiplied by the alpha values
		/// </summary>
		PreMultiplied = 0x02
	}

	public enum PixelFormatV3 : ulong
	{
		PVRTC2bppRGB = 0,
		PVRTC2bppRGBA = 1,
		PVRTC4bppRGB = 2,
		PVRTC4bppRGBA = 3,
		PVRTCII2bpp = 4,
		PVRTCII4bpp = 5,
		ETC1 = 6,
		DXT1 = 7,
		DXT2 = 8,
		DXT3 = 9,
		DXT4 = 10,
		DXT5 = 11,
		BC1 = 7,
		BC2 = 9,
		BC3 = 11,
		BC4 = 12,
		BC5 = 13,
		BC6 = 14,
		BC7 = 15,
		UYVY = 16,
		YUY2 = 17,
		BW1bpp = 18,
		R9G9B9E5SharedExponent = 19,
		RGBG8888 = 20,
		GRGB8888 = 21,
		ETC2RGB = 22,
		ETC2RGBA = 23,
		ETC2RGBA1 = 24,
		EACR11 = 25,
		EACRG11 = 26,
		ASTC4x4 = 27,
		ASTC5x4 = 28,
		ASTC5x5 = 29,
		ASTC6x5 = 30,
		ASTC6x6 = 31,
		ASTC8x5 = 32,
		ASTC8x6 = 33,
		ASTC8x8 = 34,
		ASTC10x5 = 35,
		ASTC10x6 = 36,
		ASTC10x8 = 37,
		ASTC10x10 = 38,
		ASTC12x10 = 39,
		ASTC12x12 = 40,
		ASTC3x3x3 = 41,
		ASTC4x3x3 = 42,
		ASTC4x4x3 = 43,
		ASTC4x4x4 = 44,
		ASTC5x4x4 = 45,
		ASTC5x5x4 = 46,
		ASTC5x5x5 = 47,
		ASTC6x5x5 = 48,
		ASTC6x6x5 = 49,
		ASTC6x6x6 = 50,
	}

	public enum ColorSpace : uint
	{
		LinearRGB = 0,
		sRGB = 1
	}

	public enum ChannelType : uint
	{
		UnsignedByteNormalised = 0,
		SignedByteNormalised = 1,
		UnsignedByte = 2,
		SignedByte = 3,
		UnsignedShortNormalised = 4,
		SignedShortNormalised = 5,
		UnsignedShort = 6,
		SignedShort = 7,
		UnsignedIntegerNormalised = 8,
		SignedIntegerNormalised = 9,
		UnsignedInteger = 10,
		SignedInteger = 11,
		Float = 12,
	}

	sealed public class PVRHeaderV3
	{
		public const int headerSizeInBytes = 52;

		public const uint matchingEndianness = 0x03525650;
		public const uint notMatchingEndianness = 0x50565203;

		private readonly TextureFlags textureFlags;
		private readonly PixelFormatV3 pixelFormat;
		private readonly ColorSpace colorSpace;
		private readonly ChannelType channelType;

		private readonly uint height;

		private readonly uint width;

		private readonly uint depth;

		private readonly uint numSurfaces;
		private readonly uint numFaces;
		private readonly uint mipMapCount;
		private readonly uint metaDataSizeInBytes;

		public TextureFlags GetTextureFlags()
		{
			return this.textureFlags;
		}

		public PixelFormatV3 GetPixelFormat()
		{
			return this.pixelFormat;
		}

		public ColorSpace GetColorSpace()
		{
			return this.colorSpace;
		}

		public ChannelType GetChannelType()
		{
			return this.channelType;
		}

		/// <summary>
		/// Width is a 32-bit unsigned integer representing the width of the texture stored in the texture data, in pixels
		/// </summary>
		/// <returns>Width in pixels</returns>
		public uint GetWidth()
		{
			return this.width;
		}

		/// <summary>
		/// Height is a 32-bit unsigned integer representing the height of the texture stored in the texture data, in pixels.
		/// </summary>
		/// <returns>Height in pixels</returns>
		public uint GetHeight()
		{
			return this.height;
		}

		/// <summary>
		/// Depth is a 32-bit unsigned integer representing the depth of the texture stored in the texture data, in pixels
		/// </summary>
		/// <returns>Depth in pixels</returns>
		public uint GetDepth()
		{
			return this.depth;
		}

		/// <summary>
		/// Num. Surfaces is used for texture arrays. It is a 32-bit unsigned integer representing the number of surfaces within the texture array.
		/// </summary>
		/// <returns>Number of surfaces</returns>
		public uint GetNumberOfSurfaces()
		{
			return this.numSurfaces;
		}

		public uint GetNumberOfFaces()
		{
			return this.numFaces;
		}

		public uint GetMipMapCount()
		{
			return this.mipMapCount;
		}

		public uint GetMetadataSizeInBytes()
		{
			return this.metaDataSizeInBytes;
		}

		public PVRHeaderV3(Stream inputStream)
		{

		}

		public PVRHeaderV3(byte[] inputBytes)
		{
			int currentIndex = 0;
			uint endianness = BitConverter.ToUInt32(inputBytes, currentIndex);
			bool swapEndianness = false;
			if (endianness == matchingEndianness)
			{

			}
			else if (endianness == notMatchingEndianness)
			{
				swapEndianness = true;
			}
			else
			{
				throw new ArgumentException($"Incorrect endian value {endianness}");
			}

			currentIndex += 4;

			uint textureFlagsUint = BitConverter.ToUInt32(inputBytes, currentIndex);

			if (Enum.IsDefined(typeof(TextureFlags), textureFlagsUint))
			{
				this.textureFlags = (TextureFlags)textureFlagsUint;
			}
			else
			{
				throw new ArgumentException($"Incorrect flags value {textureFlagsUint}");
			}

			currentIndex += 4;

			ulong pixelFormatUlong = BitConverter.ToUInt64(inputBytes, currentIndex);

			if (Enum.IsDefined(typeof(PixelFormatV3), pixelFormatUlong))
			{
				this.pixelFormat = (PixelFormatV3)pixelFormatUlong;
			}
			else
			{
				throw new ArgumentException($"Incorrect pixel format value {pixelFormatUlong}");
			}

			currentIndex += 8;

			uint colorSpaceUint = BitConverter.ToUInt32(inputBytes, currentIndex);

			if (Enum.IsDefined(typeof(ColorSpace), colorSpaceUint))
			{
				this.colorSpace = (ColorSpace)colorSpaceUint;
			}
			else
			{
				throw new ArgumentException($"Incorrect color space value {colorSpaceUint}");
			}

			currentIndex += 4;

			uint channelTypeUint = BitConverter.ToUInt32(inputBytes, currentIndex);

			if (Enum.IsDefined(typeof(ChannelType), channelTypeUint))
			{
				this.channelType = (ChannelType)channelTypeUint;
			}
			else
			{
				throw new ArgumentException($"Incorrect channel type value {channelTypeUint}");
			}

			currentIndex += 4;

			this.height = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.width = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.depth = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.numSurfaces = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.numFaces = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.mipMapCount = BitConverter.ToUInt32(inputBytes, currentIndex);

			currentIndex += 4;

			this.metaDataSizeInBytes = BitConverter.ToUInt32(inputBytes, currentIndex);
		}
	}
}
