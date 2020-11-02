using System;
using System.IO;
using System.Collections;

namespace CSharp_PVR
{
	/// <summary>
	/// Pixel format for V2 input
	/// </summary>
	public enum PixelFormatV2 : byte
	{
		/// <summary>
		/// ARGB 4444
		/// </summary>
		ARGB4444 = 0x0,

		/// <summary>
		/// ARGB 1555
		/// </summary>
		ARGB1555 = 0x1,

		/// <summary>
		/// RGB 565
		/// </summary>
		RGB565 = 0x2,

		/// <summary>
		/// RGB 555
		/// </summary>
		RGB555 = 0x3,

		/// <summary>
		/// RGB 888
		/// </summary>
		RGB888 = 0x4,

		/// <summary>
		/// ARGB 8888
		/// </summary>
		ARGB8888 = 0x5,

		/// <summary>
		/// ARGB 8332
		/// </summary>
		ARGB8332 = 0x6,

		/// <summary>
		/// I 8
		/// </summary>
		I8 = 0x7,

		/// <summary>
		/// AI 88
		/// </summary>
		AI88 = 0x8,

		/// <summary>
		/// 1BPP
		/// </summary>
		ONEBPP = 0x9,

		/// <summary>
		/// (V,Y1,U,Y0)
		/// </summary>
		V_Y1_U_Y0 = 0xA,

		/// <summary>
		/// (Y1,V,Y0,U)
		/// </summary>
		Y1_V_Y0_U = 0xB,

		/// <summary>
		/// PVRTC2
		/// </summary>
		PVRTC2 = 0xC,

		/// <summary>
		/// PVRTC4
		/// </summary>
		PVRTC4 = 0xD,

		/// <summary>
		/// ARGB 4444
		/// </summary>
		ARGB4444_2 = 0x10,

		/// <summary>
		/// ARGB 1555
		/// </summary>
		ARGB1555_2 = 0x11,

		/// <summary>
		/// ARGB 8888
		/// </summary>
		ARGB8888_2 = 0x12,

		/// <summary>
		/// RGB 565
		/// </summary>
		RGB565_2 = 0x13,

		/// <summary>
		/// RGB 555
		/// </summary>
		RGB555_2 = 0x14,

		/// <summary>
		/// RGB 888
		/// </summary>
		RGB888_2 = 0x15,

		/// <summary>
		/// I 8
		/// </summary>
		I8_2 = 0x16,

		/// <summary>
		/// AI 88
		/// </summary>
		AI88_2 = 0x17,

		/// <summary>
		/// PVRTC2
		/// </summary>
		PVRTC2_2 = 0x18,

		/// <summary>
		/// PVRTC4
		/// </summary>
		PVRTC4_2 = 0x19,

		/// <summary>
		/// BGRA 8888
		/// </summary>
		BGRA8888 = 0x1A,

		/// <summary>
		/// DXT1
		/// </summary>
		DXT1 = 0x20,

		/// <summary>
		/// DXT2
		/// </summary>
		DXT2 = 0x21,

		/// <summary>
		/// DXT3
		/// </summary>
		DXT3 = 0x22,

		/// <summary>
		/// DXT4
		/// </summary>
		DXT4 = 0x23,

		/// <summary>
		/// DXT5
		/// </summary>
		DXT5 = 0x24,

		/// <summary>
		/// RGB 332
		/// </summary>
		RGB332 = 0x25,

		/// <summary>
		/// AL 44
		/// </summary>
		AL44 = 0x26,

		/// <summary>
		/// LVU 655
		/// </summary>
		LVU655 = 0x27,

		/// <summary>
		/// XLVU 8888
		/// </summary>
		XLVU8888 = 0x28,

		/// <summary>
		/// QWVU 8888
		/// </summary>
		QWVU8888 = 0x29,

		/// <summary>
		/// ABGR 2101010
		/// </summary>
		ABGR2101010 = 0x2A,

		/// <summary>
		/// ARGB 2101010
		/// </summary>
		ARGB2101010 = 0x2B,

		/// <summary>
		/// AWVU 2101010
		/// </summary>
		AWVU2101010 = 0x2C,

		/// <summary>
		/// GR 1616
		/// </summary>
		GR1616 = 0x2D,

		/// <summary>
		/// VU 1616
		/// </summary>
		VU1616 = 0x2E,

		/// <summary>
		/// ABGR 16161616
		/// </summary>
		ABGR16161616 = 0x2F,

		/// <summary>
		/// R 16F
		/// </summary>
		R16F = 0x30,

		/// <summary>
		/// GR 1616F
		/// </summary>
		GR1616F = 0x31,

		/// <summary>
		/// ABGR 16161616F
		/// </summary>
		ABGR16161616F = 0x32,

		/// <summary>
		/// R 32F
		/// </summary>
		R32F = 0x33,

		/// <summary>
		/// GR 3232F
		/// </summary>
		GR3232F = 0x34,

		/// <summary>
		/// ABGR 32323232F
		/// </summary>
		ABGR32323232F = 0x35,

		/// <summary>
		/// ETC
		/// </summary>
		ETC = 0x36,

		/// <summary>
		/// A 8
		/// </summary>
		A8 = 0x40,

		/// <summary>
		/// VU 88
		/// </summary>
		VU88 = 0x41,

		/// <summary>
		/// L 16
		/// </summary>
		L16 = 0x42,

		/// <summary>
		/// L 8
		/// </summary>
		L8 = 0x43,

		/// <summary>
		/// AL 88
		/// </summary>
		AL88 = 0x44,

		/// <summary>
		/// UYVY
		/// </summary>
		UYVY = 0x45,

		/// <summary>
		/// YUY2
		/// </summary>
		YUY2 = 0x46
	}

	/// <summary>
	/// PVR V2 header
	/// </summary>
	sealed public class PVRHeaderV2
	{
		/// <summary>
		/// Valid header size in bytes
		/// </summary>
		public const uint validHeaderSizeInBytes = 52;

		/// <summary>
		/// Valid file identifier
		/// </summary>
		public const uint validFileIdentifier = 0x21525650;

		private readonly uint height;

		private readonly uint width;

		private readonly uint mipMapCount;

		private readonly PixelFormatV2 pixelFormat;

		private readonly BitArray flags;

		private readonly uint surfaceSize;

		private readonly uint bitsPerPixel;

		private readonly uint redChannelMaskAsUint;

		private readonly uint greenChannelMaskAsUint;

		private readonly uint blueChannelMaskAsUint;

		private readonly uint alphaChannelMaskAsUint;

		private readonly uint numberOfSurfaces;

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
		/// Pixel Format is an 8-bit unsigned integer containing the pixel format of the texture data
		/// </summary>
		/// <returns>PixelFormatV2</returns>
		public PixelFormatV2 GetPixelFormat()
		{
			return this.pixelFormat;
		}

		/// <summary>
		/// MIP-Map Count is a 32bit unsigned integer representing the number of MIP-Map levels present, excluding the top level. A value of zero, therefore, means that only the top level texture exists. If this value is anything other than 0, the MIP Map flag should be set
		/// </summary>
		/// <returns>Mip-Map count</returns>
		public uint GetMipMapCount()
		{
			return this.mipMapCount;
		}

		/// <summary>
		/// Flags say MIP-Maps are present
		/// </summary>
		/// <returns>True if are present; False otherwise</returns>
		public bool AreMipMapsPresentFlag()
		{
			return this.flags[0];
		}

		/// <summary>
		/// This is a 32bit unsigned integer representing the number of bytes per single surface within the texture.
		/// </summary>
		/// <returns>Surface size</returns>
		public uint GetSurfaceSize()
		{
			return this.surfaceSize;
		}

		/// <summary>
		/// This is a 32bit unsigned integer representing the total number of bits of data that make up a single pixel.
		/// </summary>
		/// <returns></returns>
		public uint GetBitsPerPixel()
		{
			return this.bitsPerPixel;
		}

		/// <summary>
		/// Each of the Red, Green, Blue and Alpha channel masks are used to determine the bits occupied by each channel in a colour format. Each mask is a bitfield value where a value of 1 indicates that this bit is used by the relevant channel.
		/// </summary>
		/// <returns></returns>
		public uint GetRedChannelMaskAsUint()
		{
			return this.redChannelMaskAsUint;
		}

		/// <summary>
		/// Each of the Red, Green, Blue and Alpha channel masks are used to determine the bits occupied by each channel in a colour format. Each mask is a bitfield value where a value of 1 indicates that this bit is used by the relevant channel.
		/// </summary>
		/// <returns></returns>
		public uint GetGreenChannelMaskAsUint()
		{
			return this.greenChannelMaskAsUint;
		}

		/// <summary>
		/// Each of the Red, Green, Blue and Alpha channel masks are used to determine the bits occupied by each channel in a colour format. Each mask is a bitfield value where a value of 1 indicates that this bit is used by the relevant channel.
		/// </summary>
		/// <returns></returns>
		public uint GetBlueChannelMaskAsUint()
		{
			return this.blueChannelMaskAsUint;
		}

		/// <summary>
		/// Each of the Red, Green, Blue and Alpha channel masks are used to determine the bits occupied by each channel in a colour format. Each mask is a bitfield value where a value of 1 indicates that this bit is used by the relevant channel.
		/// </summary>
		/// <returns></returns>
		public uint GetAlphaChannelMaskAsUint()
		{
			return this.alphaChannelMaskAsUint;
		}

		/// <summary>
		/// The number of surfaces is a 32bit unsigned integer, signifying the number of distinct surfaces in the texture data. A distinct surface is either a cube map face, a slice of a volume texture, or a member of a texture array, depending on the flags
		/// </summary>
		/// <returns>Number of surfaces</returns>
		public uint GetNumberOfSurfaces()
		{
			return this.numberOfSurfaces;
		}

		/// <summary>
		/// Constructor for PVR header V2
		/// </summary>
		/// <param name="input">Input stream</param>
		/// <param name="leaveStreamOpen">Leave stream open after reading it</param>
		public PVRHeaderV2(Stream input, bool leaveStreamOpen = true)
		{
			if (input == null)
			{
				throw new ArgumentNullException("Input is null");
			}

			using (BinaryReader reader = new BinaryReader(input, System.Text.Encoding.UTF8, leaveOpen: true))
			{
				uint readHeaderSize = reader.ReadUInt32();

				if (readHeaderSize != validHeaderSizeInBytes)
				{
					throw new InvalidOperationException($"Header size is not valid, it should be {validHeaderSizeInBytes} but it is {readHeaderSize}");
				}

				this.height = reader.ReadUInt32();

				this.width = reader.ReadUInt32();

				this.mipMapCount = reader.ReadUInt32();

				byte pixelFormatAsByte = reader.ReadByte();

				if (PixelFormatV2.IsDefined(typeof(PixelFormatV2), pixelFormatAsByte))
				{
					this.pixelFormat = (PixelFormatV2)pixelFormatAsByte;
				}
				else
				{
					throw new InvalidOperationException($"Cannot identify pixel format with value {pixelFormatAsByte}");
				}

				this.flags = new BitArray(reader.ReadBytes(3));

				this.surfaceSize = reader.ReadUInt32();

				this.bitsPerPixel = reader.ReadUInt32();

				this.redChannelMaskAsUint = reader.ReadUInt32();

				this.greenChannelMaskAsUint = reader.ReadUInt32();

				this.blueChannelMaskAsUint = reader.ReadUInt32();

				this.alphaChannelMaskAsUint = reader.ReadUInt32();

				uint pvrFileIdentifier = reader.ReadUInt32();

				if (pvrFileIdentifier != validFileIdentifier)
				{
					throw new InvalidOperationException($"PVR File Identifier is not valid, it should be {validFileIdentifier} but it is {pvrFileIdentifier}");
				}

				this.numberOfSurfaces = reader.ReadUInt32();
			}
		}
	}
}