using System;

namespace CoreLib.System.Text
{
	public class StringBuilder
	{
		/// <summary>
		/// The character buffer for this chunk.
		/// </summary>
		private char[] m_ChunkChars;

		/// <summary>
		/// The chunk that logically precedes this chunk.
		/// </summary>
		private StringBuilder? m_ChunkPrevious;

		/// <summary>
		/// The number of characters in this chunk.
		/// This is the number of elements in <see cref="m_ChunkChars"/> that are in use, from the start of the buffer.
		/// </summary>
		private int m_ChunkLength;

		/// <summary>
		/// The logical offset of this chunk's characters in the string it is a part of.
		/// This is the sum of the number of characters in preceding blocks.
		/// </summary>
		private int m_ChunkOffset;

		/// <summary>
		/// The maximum capacity this builder is allowed to have.
		/// </summary>
		private int m_MaxCapacity;

		/// <summary>
		/// The default capacity of a <see cref="StringBuilder"/>.
		/// </summary>
		private const int DefaultCapacity = 16;

		private const string CapacityField = "Capacity"; // Do not rename (binary serialization)
		private const string MaxCapacityField = "m_MaxCapacity"; // Do not rename (binary serialization)
		private const string StringValueField = "m_StringValue"; // Do not rename (binary serialization)
		private const string ThreadIDField = "m_currentThread"; // Do not rename (binary serialization)

		// We want to keep chunk arrays out of large object heap (< 85K bytes ~ 40K chars) to be sure.
		// Making the maximum chunk size big means less allocation code called, but also more waste
		// in unused characters and slower inserts / replaces (since you do need to slide characters over
		// within a buffer).
		private const int MaxChunkSize = 8000;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class.
		/// </summary>
		public StringBuilder()
		{
			m_MaxCapacity = int.MaxValue;
			m_ChunkChars = new char[DefaultCapacity];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class.
		/// </summary>
		/// <param name="capacity">The initial capacity of this builder.</param>
		public StringBuilder(int capacity)
			: this(capacity, int.MaxValue)
		{
		}

		///// <summary>
		///// Initializes a new instance of the <see cref="StringBuilder"/> class.
		///// </summary>
		///// <param name="value">The initial contents of this builder.</param>
		//public StringBuilder(string? value)
		//	: this(value, DefaultCapacity)
		//{
		//}

		///// <summary>
		///// Initializes a new instance of the <see cref="StringBuilder"/> class.
		///// </summary>
		///// <param name="value">The initial contents of this builder.</param>
		///// <param name="capacity">The initial capacity of this builder.</param>
		//public StringBuilder(string? value, int capacity)
		//	: this(value, 0, value?.Length ?? 0, capacity)
		//{
		//}

		///// <summary>
		///// Initializes a new instance of the <see cref="StringBuilder"/> class.
		///// </summary>
		///// <param name="value">The initial contents of this builder.</param>
		///// <param name="startIndex">The index to start in <paramref name="value"/>.</param>
		///// <param name="length">The number of characters to read in <paramref name="value"/>.</param>
		///// <param name="capacity">The initial capacity of this builder.</param>
		//public StringBuilder(string? value, int startIndex, int length, int capacity)
		//{
		//	//if (capacity < 0)
		//	//{
		//	//	throw new ArgumentOutOfRangeException(nameof(capacity), SR.Format(SR.ArgumentOutOfRange_MustBePositive, nameof(capacity)));
		//	//}
		//	//if (length < 0)
		//	//{
		//	//	throw new ArgumentOutOfRangeException(nameof(length), SR.Format(SR.ArgumentOutOfRange_MustBeNonNegNum, nameof(length)));
		//	//}
		//	//if (startIndex < 0)
		//	//{
		//	//	throw new ArgumentOutOfRangeException(nameof(startIndex), SR.ArgumentOutOfRange_StartIndex);
		//	//}

		//	if (value == null)
		//	{
		//		value = string.Empty;
		//	}
		//	if (startIndex > value.Length - length)
		//	{
		//		//throw new ArgumentOutOfRangeException(nameof(length), SR.ArgumentOutOfRange_IndexLength);
		//	}

		//	m_MaxCapacity = int.MaxValue;
		//	if (capacity == 0)
		//	{
		//		capacity = DefaultCapacity;
		//	}
		//	capacity = Math.Max(capacity, length);

		//	m_ChunkChars = new char[capacity];
		//	m_ChunkLength = length;

		//	//value.AsSpan(startIndex, length).CopyTo(m_ChunkChars);
		//	//Array.
		//}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class.
		/// </summary>
		/// <param name="capacity">The initial capacity of this builder.</param>
		/// <param name="maxCapacity">The maximum capacity of this builder.</param>
		public StringBuilder(int capacity, int maxCapacity)
		{
			//if (capacity > maxCapacity)
			//{
			//	throw new ArgumentOutOfRangeException(nameof(capacity), SR.ArgumentOutOfRange_Capacity);
			//}
			//if (maxCapacity < 1)
			//{
			//	throw new ArgumentOutOfRangeException(nameof(maxCapacity), SR.ArgumentOutOfRange_SmallMaxCapacity);
			//}
			//if (capacity < 0)
			//{
			//	throw new ArgumentOutOfRangeException(nameof(capacity), SR.Format(SR.ArgumentOutOfRange_MustBePositive, nameof(capacity)));
			//}

			if (capacity == 0)
			{
				capacity = Math.Min(DefaultCapacity, maxCapacity);
			}

			m_MaxCapacity = maxCapacity;
			m_ChunkChars = new char[capacity];
		}

		/// <summary>
		/// Gets the maximum capacity this builder is allowed to have.
		/// </summary>
		public int MaxCapacity => m_MaxCapacity;

	}
}
