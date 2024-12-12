using System;
using System.IO;
using System.Collections;

namespace CSharp_PVR
{
	/// <summary>
	/// Metadata type
	/// </summary>
	public enum MetadataTypeV3 : uint
	{
		/// <summary>
		/// Atlas limits
		/// </summary>
		AtlasLimits = 0,

		/// <summary>
		/// Normal map info
		/// </summary>
		NormalMapInfo = 1,
		
		/// <summary>
		/// Cubemap orientation
		/// </summary>
		CubemapOrientation = 2,

		/// <summary>
		/// Logical orientation
		/// </summary>
		LogicalOrientation = 3,

		/// <summary>
		/// Border sizes
		/// </summary>
		BorderSizes = 4,

		/// <summary>
		/// Padding data
		/// </summary>
		PaddingData = 5,

		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = uint.MaxValue,
	}

	/// <summary>
	/// Metadata element for V3 files
	/// </summary>
	sealed public class PVRMetadataElementV3
	{
		private static readonly byte[] onlyValidFourcc = new byte[] {  0x50, 0x56, 0x52, 0x03 };

		private readonly MetadataTypeV3 dataType;

		private readonly byte[] dataAsByteArray;

		/// <summary>
		/// Get metadata type
		/// </summary>
		/// <returns>MetadataTypeV3</returns>
		public MetadataTypeV3 GetMetadataType()
		{
			return this.dataType;
		}

		/// <summary>
		/// Get data as byte array
		/// </summary>
		/// <returns>Byte array</returns>
		public byte[] GetDataAsByteArray()
		{
			return this.dataAsByteArray;
		}

		/// <summary>
		/// Constructor for PVR metadata element V3
		/// </summary>
		/// <param name="inputStream">Input stream</param>
		/// <param name="leaveStreamOpen">Leave stream open after reading</param>
		public PVRMetadataElementV3(Stream inputStream, bool leaveStreamOpen = true)
		{
			using (BinaryReader reader = new BinaryReader(inputStream, System.Text.Encoding.UTF8, leaveOpen: leaveStreamOpen))
			{
				byte[] fourCC = reader.ReadBytes(4);
				if (!StructuralComparisons.StructuralEqualityComparer.Equals(onlyValidFourcc, fourCC))
				{
					string invalidValueAsHex = string.Concat(Array.ConvertAll(fourCC, x => x.ToString("X2")));
					throw new ArgumentException($"Not valid FourCC for Metadata, invalid array is {invalidValueAsHex}");
				}

				uint keyAsUint = reader.ReadUInt32();

				if (Enum.IsDefined(typeof(MetadataTypeV3), keyAsUint))
				{
					this.dataType = (MetadataTypeV3)keyAsUint;
				}
				else
				{
					this.dataType = MetadataTypeV3.Unknown;
				}

				uint dataSize = reader.ReadUInt32();

				// Validate certain values
				if (this.dataType == MetadataTypeV3.NormalMapInfo && dataSize != 8)
				{
					throw new ArgumentException($"Normal map information should be 8 bytes, but it is {dataSize}");
				}
				else if (this.dataType == MetadataTypeV3.CubemapOrientation && dataSize != 6)
				{
					throw new ArgumentException($"Cubemap orientation should be 6 bytes, but it is {dataSize}");
				}
				else if (this.dataType == MetadataTypeV3.LogicalOrientation && dataSize != 3)
				{
					throw new ArgumentException($"Logical orientation should be 3 bytes, but it is {dataSize}");
				}
				else if (this.dataType == MetadataTypeV3.BorderSizes && dataSize != 12)
				{
					throw new ArgumentException($"Border sizes should be 12 bytes, but it is {dataSize}");
				}

				this.dataAsByteArray = reader.ReadBytes((int)dataSize);
			}
		}

		/// <summary>
		/// Constructor for PVR metadata element V3
		/// </summary>
		/// <param name="inputData">Input data byte array</param>
		/// <param name="index">Start index</param>
		/// <param name="count">How many bytes to read</param>
		public PVRMetadataElementV3(byte[] inputData, int index, int count) : this(new MemoryStream(inputData, index, count, writable: false))
		{

		}

		/// <summary>
		/// How much to read in bytes
		/// </summary>
		/// <param name="inputData">Input data as byte array</param>
		/// <param name="index">Index</param>
		/// <returns>How many bytes to read for this element</returns>
		public static int GetHowMuchToReadInBytes(byte[] inputData, int index)
		{
			return BitConverter.ToInt32(inputData, index + 8) + 12;
		}
	}
}