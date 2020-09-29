using System;
using System.IO;
using System.Collections;

namespace CSharp_PVR
{
	public enum PixelFormatV2 : byte
	{
		ARGB4444 = 0x0,
		ARGB1555 = 0x1,
		RGB565 = 0x2,
		RGB555 = 0x3,
		RGB888 = 0x4,
		ARGB8888 = 0x5,
		ARGB8332 = 0x6,
		I8 = 0x7,
		AI88 = 0x8,
		ONEBPP = 0x9,
		V_Y1_U_Y0 = 0xA,
		Y1_V_Y0_U = 0xB,
		PVRTC2 = 0xC,
		PVRTC4 = 0xD,
		ARGB4444_2 = 0x10,
		ARGB1555_2 = 0x11,
		ARGB8888_2 = 0x12,
		RGB565_2 = 0x13,
		RGB555_2 = 0x14,
		RGB888_2 = 0x15,
		I8_2 = 0x16,
		AI88_2 = 0x17,
		PVRTC2_2 = 0x18,
		PVRTC4_2 = 0x19,
		BGRA8888 = 0x1A,
		DXT1 = 0x20,
		DXT2 = 0x21,
		DXT3 = 0x22,
		DXT4 = 0x23,
		DXT5 = 0x24,
		RGB332 = 0x25,
		AL44 = 0x26,
		LVU655 = 0x27,

		XLVU8888 = 0x28,
		QWVU8888 = 0x29,
		ABGR2101010 = 0x2A,
		ARGB2101010 = 0x2B,
		AWVU2101010 = 0x2C,
		GR1616 = 0x2D,
		VU1616 = 0x2E,
		ABGR16161616 = 0x2F,
		R16F = 0x30,
		GR1616F = 0x31,
		ABGR16161616F = 0x32,
		R32F = 0x33,
		GR3232F = 0x34,
		ABGR32323232F = 0x35,
		ETC = 0x36,
		A8 = 0x40,
		VU88 = 0x41,
		L16 = 0x42,
		L8 = 0x43,
		AL88 = 0x44,
		UYVY = 0x45,
		YUY2 = 0x46
	}

	sealed public class PVRHeaderV2
	{
		public const uint validHeaderSizeInBytes = 52;

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

		public PVRHeaderV2(Stream input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("Input is null");
			}

			using (BinaryReader reader = new BinaryReader(input))
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