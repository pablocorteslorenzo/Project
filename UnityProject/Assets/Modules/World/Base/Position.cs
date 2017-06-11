
public struct Position
{
	public int x;
	public int y;

	public static readonly Position zero = new Position(0, 0);
	public static readonly Position one = new Position(1, 1);

	public Position(int _x, int _y)
	{
		x = _x;
		y = _y;
	}

	public Position Move(int _x, int _y)
	{
		return new Position(x + _x, y + _y);
	}

	public Position MoveX(int _x)
	{
		return new Position(x + _x, y);
	}

	public Position MoveY(int _y)
	{
		return new Position(x, y + _y);
	}

	public static Position operator +(Position _a, Position _b)
	{
		return new Position(_a.x + _b.x, _a.y + _b.y);
	}

	public static Position operator -(Position _a, Position _b)
	{
		return new Position(_a.x - _b.x, _a.y - _b.y);
	}

	public static Position operator *(Position _a, int _value)
	{
		return new Position(_a.x * _value, _a.y * _value);
	}

	public static int Distance(Position _a, Position _b)
	{
		return System.Math.Abs(_a.x - _b.x) + System.Math.Abs(_a.y - _b.y);
	}

	public static int DistanceX(Position _a, Position _b)
	{
		return System.Math.Abs(_a.x - _b.x);
	}

	public static int DistanceY(Position _a, Position _b)
	{
		return System.Math.Abs(_a.y - _b.y);
	}
}
