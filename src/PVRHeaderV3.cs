using System;
using System.IO;

namespace CSharp_PVR
{
	/// <summary>
	/// Texture flags
	/// </summary>
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

	/// <summary>
	/// Pixel format V3
	/// </summary>
	public enum PixelFormatV3 : ulong
	{
		/// <summary>
		/// PVRTC 2bpp RGB
		/// </summary>
		PVRTC2bppRGB = 0,

		/// <summary>
		/// PVRTC 2bpp RGBA
		/// </summary>
		PVRTC2bppRGBA = 1,

		/// <summary>
		/// PVRTC 4bpp RGB
		/// </summary>
		PVRTC4bppRGB = 2,

		/// <summary>
		/// PVRTC 4bpp RGBA
		/// </summary>
		PVRTC4bppRGBA = 3,

		/// <summary>
		/// PVRTC-II 2bpp
		/// </summary>
		PVRTCII2bpp = 4,

		/// <summary>
		/// PVRTC-II 4bpp
		/// </summary>
		PVRTCII4bpp = 5,

		/// <summary>
		/// ETC1
		/// </summary>
		ETC1 = 6,

		/// <summary>
		/// DXT1
		/// </summary>
		DXT1 = 7,

		/// <summary>
		/// DXT2
		/// </summary>
		DXT2 = 8,

		/// <summary>
		/// DXT3
		/// </summary>
		DXT3 = 9,

		/// <summary>
		/// DXT4
		/// </summary>
		DXT4 = 10,

		/// <summary>
		/// DXT5
		/// </summary>
		DXT5 = 11,

		/// <summary>
		/// BC1
		/// </summary>
		BC1 = 7,

		/// <summary>
		/// BC2
		/// </summary>
		BC2 = 9,

		/// <summary>
		/// BC3
		/// </summary>
		BC3 = 11,

		/// <summary>
		/// BC4
		/// </summary>
		BC4 = 12,

		/// <summary>
		/// BC5
		/// </summary>
		BC5 = 13,

		/// <summary>
		/// BC6
		/// </summary>
		BC6 = 14,

		/// <summary>
		/// BC7
		/// </summary>
		BC7 = 15,

		/// <summary>
		/// UYVY
		/// </summary>
		UYVY = 16,

		/// <summary>
		/// YUY2
		/// </summary>
		YUY2 = 17,

		/// <summary>
		/// BW1bpp
		/// </summary>
		BW1bpp = 18,

		/// <summary>
		/// R9G9B9E5 Shared Exponent
		/// </summary>
		R9G9B9E5SharedExponent = 19,

		/// <summary>
		/// RGBG8888
		/// </summary>
		RGBG8888 = 20,

		/// <summary>
		/// GRGB8888
		/// </summary>
		GRGB8888 = 21,

		/// <summary>
		/// ETC2 RGB
		/// </summary>
		ETC2RGB = 22,

		/// <summary>
		/// ETC2 RGBA
		/// </summary>
		ETC2RGBA = 23,

		/// <summary>
		/// ETC2 RGB A1
		/// </summary>
		ETC2RGBA1 = 24,

		/// <summary>
		/// EAC R11
		/// </summary>
		EACR11 = 25,

		/// <summary>
		/// EAC RG11
		/// </summary>
		EACRG11 = 26,

		/// <summary>
		/// ASTC_4x4
		/// </summary>
		ASTC4x4 = 27,

		/// <summary>
		/// ASTC_5x4
		/// </summary>
		ASTC5x4 = 28,

		/// <summary>
		/// ASTC_5x5
		/// </summary>
		ASTC5x5 = 29,

		/// <summary>
		/// ASTC_6x5
		/// </summary>
		ASTC6x5 = 30,

		/// <summary>
		/// ASTC_6x6
		/// </summary>
		ASTC6x6 = 31,

		/// <summary>
		/// ASTC_8x5
		/// </summary>
		ASTC8x5 = 32,

		/// <summary>
		/// ASTC_8x6
		/// </summary>
		ASTC8x6 = 33,

		/// <summary>
		/// ASTC_8x8
		/// </summary>
		ASTC8x8 = 34,

		/// <summary>
		/// ASTC_10x5
		/// </summary>
		ASTC10x5 = 35,

		/// <summary>
		/// ASTC_10x6
		/// </summary>
		ASTC10x6 = 36,

		/// <summary>
		/// ASTC_10x8
		/// </summary>
		ASTC10x8 = 37,

		/// <summary>
		/// ASTC_10x10
		/// </summary>
		ASTC10x10 = 38,

		/// <summary>
		/// ASTC_12x10
		/// </summary>
		ASTC12x10 = 39,

		/// <summary>
		/// ASTC_12x12
		/// </summary>
		ASTC12x12 = 40,

		/// <summary>
		/// ASTC_3x3x3
		/// </summary>
		ASTC3x3x3 = 41,

		/// <summary>
		/// ASTC_4x3x3
		/// </summary>
		ASTC4x3x3 = 42,

		/// <summary>
		/// ASTC_4x4x3
		/// </summary>
		ASTC4x4x3 = 43,

		/// <summary>
		/// ASTC_4x4x4
		/// </summary>
		ASTC4x4x4 = 44,

		/// <summary>
		/// ASTC_5x4x4
		/// </summary>
		ASTC5x4x4 = 45,

		/// <summary>
		/// ASTC_5x5x4
		/// </summary>
		ASTC5x5x4 = 46,

		/// <summary>
		/// ASTC_5x5x5
		/// </summary>
		ASTC5x5x5 = 47,

		/// <summary>
		/// ASTC_6x5x5
		/// </summary>
		ASTC6x5x5 = 48,

		/// <summary>
		/// ASTC_6x6x5
		/// </summary>
		ASTC6x6x5 = 49,

		/// <summary>
		/// ASTC_6x6x6
		/// </summary>
		ASTC6x6x6 = 50,
	}

	/// <summary>
	/// Color space
	/// </summary>
	public enum ColorSpace : uint
	{
		/// <summary>
		/// Texture data is in the Linear RGB colour space
		/// </summary>
		LinearRGB = 0,

		/// <summary>
		/// Texture data is in the Standard RGB colour space
		/// </summary>
		sRGB = 1
	}

	/// <summary>
	/// Channel type
	/// </summary>
	public enum ChannelType : uint
	{
		/// <summary>
		/// Unsigned Byte Normalised 
		/// </summary>
		UnsignedByteNormalised = 0,

		/// <summary>
		/// Signed Byte Normalised
		/// </summary>
		SignedByteNormalised = 1,

		/// <summary>
		/// Unsigned Byte
		/// </summary>
		UnsignedByte = 2,

		/// <summary>
		/// Signed Byte
		/// </summary>
		SignedByte = 3,

		/// <summary>
		/// Unsigned Short Normalised
		/// </summary>
		UnsignedShortNormalised = 4,

		/// <summary>
		/// Signed Short Normalised
		/// </summary>
		SignedShortNormalised = 5,

		/// <summary>
		/// Unsigned Short
		/// </summary>
		UnsignedShort = 6,

		/// <summary>
		/// Signed Short
		/// </summary>
		SignedShort = 7,

		/// <summary>
		/// Unsigned Integer Normalised
		/// </summary>
		UnsignedIntegerNormalised = 8,

		/// <summary>
		/// Signed Integer Normalised
		/// </summary>
		SignedIntegerNormalised = 9,

		/// <summary>
		/// Unsigned Integer
		/// </summary>
		UnsignedInteger = 10,

		/// <summary>
		/// Signed Integer
		/// </summary>
		SignedInteger = 11,

		/// <summary>
		/// Float
		/// </summary>
		Float = 12,
	}

	/// <summary>
	/// PVR Header V3
	/// </summary>
	sealed public class PVRHeaderV3
	{
		/// <summary>
		/// Only valid header size in bytes
		/// </summary>
		public const int headerSizeInBytes = 52;

		/// <summary>
		/// Matching endianness
		/// </summary>
		public const uint matchingEndianness = 0x03525650;

		/// <summary>
		/// Endianness needing reverse
		/// </summary>
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

		/// <summary>
		/// Get texture flags
		/// </summary>
		/// <returns>TextureFlags</returns>
		public TextureFlags GetTextureFlags()
		{
			return this.textureFlags;
		}

		/// <summary>
		/// Get pixel format
		/// </summary>
		/// <returns>PixelFormatV3</returns>
		public PixelFormatV3 GetPixelFormat()
		{
			return this.pixelFormat;
		}

		/// <summary>
		/// Get color space
		/// </summary>
		/// <returns>ColorSpace</returns>
		public ColorSpace GetColorSpace()
		{
			return this.colorSpace;
		}

		/// <summary>
		/// Get channel type
		/// </summary>
		/// <returns>ChannelType</returns>
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

		/// <summary>
		/// Num. Faces is a 32-bit unsigned integer that represents the number of faces in a cubemap.
		/// </summary>
		/// <returns>Number of faces</returns>
		public uint GetNumberOfFaces()
		{
			return this.numFaces;
		}

		/// <summary>
		/// MIP-Map Count is a 32-bit unsigned integer representing the number of MIP-Map levels present including the top level. A value of one, therefore, means that only the top level texture exists.
		/// </summary>
		/// <returns>Mip-map count</returns>
		public uint GetMipMapCount()
		{
			return this.mipMapCount;
		}

		/// <summary>
		/// Meta Data Size is a 32-bit unsigned integer representing the total size (in bytes) of all the metadata following the header.
		/// </summary>
		/// <returns>Metadata size</returns>
		public uint GetMetadataSizeInBytes()
		{
			return this.metaDataSizeInBytes;
		}

		/// <summary>
		/// Constructor for PVR header V3
		/// </summary>
		/// <param name="inputStream">Input stream</param>
		public PVRHeaderV3(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new NullReferenceException("inputStream is null");
			}

			if (!inputStream.CanRead)
			{
				throw new ArgumentException("inputStream must be readable");
			}

			using (BinaryReader reader = new BinaryReader(inputStream, System.Text.Encoding.UTF8, leaveOpen: true))
			{
				uint endianness = reader.ReadUInt32();
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

				uint textureFlagsUint = reader.ReadUInt32();

				if (Enum.IsDefined(typeof(TextureFlags), textureFlagsUint))
				{
					this.textureFlags = (TextureFlags)textureFlagsUint;
				}
				else
				{
					throw new ArgumentException($"Incorrect flags value {textureFlagsUint}");
				}

				ulong pixelFormatUlong = reader.ReadUInt64();

				if (Enum.IsDefined(typeof(PixelFormatV3), pixelFormatUlong))
				{
					this.pixelFormat = (PixelFormatV3)pixelFormatUlong;
				}
				else
				{
					throw new ArgumentException($"Incorrect pixel format value {pixelFormatUlong}");
				}

				uint colorSpaceUint = reader.ReadUInt32();

				if (Enum.IsDefined(typeof(ColorSpace), colorSpaceUint))
				{
					this.colorSpace = (ColorSpace)colorSpaceUint;
				}
				else
				{
					throw new ArgumentException($"Incorrect color space value {colorSpaceUint}");
				}

				uint channelTypeUint = reader.ReadUInt32();

				if (Enum.IsDefined(typeof(ChannelType), channelTypeUint))
				{
					this.channelType = (ChannelType)channelTypeUint;
				}
				else
				{
					throw new ArgumentException($"Incorrect channel type value {channelTypeUint}");
				}

				this.height = reader.ReadUInt32();

				this.width = reader.ReadUInt32();

				this.depth = reader.ReadUInt32();

				this.numSurfaces = reader.ReadUInt32();

				this.numFaces = reader.ReadUInt32();

				this.mipMapCount = reader.ReadUInt32();

				this.metaDataSizeInBytes = reader.ReadUInt32();
			}
		}

		/// <summary>
		/// Constructor for PVR header V3
		/// </summary>
		/// <param name="inputBytes">Input byte array</param>
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

		/// <summary>
		/// Calculate how many bytes of data certain mip map level should take
		/// </summary>
		/// <param name="pixelFormat">Pixel format</param>
		/// <param name="width">Width</param>
		/// <param name="height">Height</param>
		/// <returns>Amount of bytes needed for mipmap level</returns>
		public static int CalculateBytesOfData(PixelFormatV3 pixelFormat, int width, int height)
		{
			if (pixelFormat == PixelFormatV3.PVRTC2bppRGB || pixelFormat == PixelFormatV3.PVRTC2bppRGBA)
			{
				return (width * height / 4);
			}
			else if (pixelFormat == PixelFormatV3.PVRTC4bppRGB || pixelFormat == PixelFormatV3.PVRTC4bppRGBA)
			{
				return (width * height / 2);
			}

			throw new NotImplementedException();
		}
	}
}
