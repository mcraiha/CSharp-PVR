using System;
using System.IO;
using System.Collections.Generic;

namespace CSharp_PVR
{
	/// <summary>
	/// PVR metadata V3
	/// </summary>
	sealed public class PVRMetadataV3
	{
		private readonly PVRMetadataElementV3[] elements;

		/// <summary>
		/// Get single elements of metadata as array 
		/// </summary>
		/// <returns>PVRMetadataElementV3[]</returns>
		public PVRMetadataElementV3[] GetElements()
		{
			return this.elements;
		}

		/// <summary>
		/// Constuctor for PVR metadata V3
		/// </summary>
		/// <param name="inputStream">Input stream</param>
		/// <param name="length">How many bytes should the metadata be</param>
		public PVRMetadataV3(Stream inputStream, int length)
		{
			if (inputStream == null)
			{
				throw new NullReferenceException("inputStream is null");
			}

			if (!inputStream.CanRead)
			{
				throw new ArgumentException("inputStream must be readable");
			}

			if (length < 0)
			{
				throw new ArgumentException($"Length cannot be negative!");
			}

			// No metadata
			if (length == 0)
			{
				this.elements = new PVRMetadataElementV3[0];
				return;
			}

			List<PVRMetadataElementV3> elements = new List<PVRMetadataElementV3>();

			long startPos = inputStream.Position;
			long currentPos = startPos;
			while (currentPos - startPos < length)
			{
				elements.Add(new PVRMetadataElementV3(inputStream));
				currentPos = inputStream.Position;
			}
			
			this.elements = elements.ToArray();
		}

		/// <summary>
		/// Constuctor for PVR metadata V3
		/// </summary>
		/// <param name="inputBytes">Input bytes array</param>
		/// <param name="startPos">Start position</param>
		/// <param name="length">How many bytes to read</param>
		public PVRMetadataV3(byte[] inputBytes, int startPos, int length)
		{
			if (inputBytes == null)
			{
				throw new NullReferenceException("inputBytes is null");
			}

			if (startPos < 0)
			{
				throw new ArgumentException($"Start position cannot be negative!");
			}
			else if (startPos > inputBytes.Length)
			{
				throw new ArgumentException($"Start position cannot be larger than input!");
			}

			if (length < 0)
			{
				throw new ArgumentException($"Length cannot be negative!");
			}
			else if (length + startPos > inputBytes.Length)
			{
				throw new ArgumentException($"Start position + Length would index over the input bytes!");
			}

			// No metadata
			if (length == 0)
			{
				this.elements = new PVRMetadataElementV3[0];
				return;
			}

			List<PVRMetadataElementV3> elements = new List<PVRMetadataElementV3>();

			int currentPos = startPos;
			while (currentPos - startPos < length)
			{
				int readThisMuch = PVRMetadataElementV3.GetHowMuchToReadInBytes(inputBytes, currentPos);
				elements.Add(new PVRMetadataElementV3(inputBytes, currentPos, readThisMuch));
				currentPos += readThisMuch;
			}
			
			this.elements = elements.ToArray();
		}
	}
}