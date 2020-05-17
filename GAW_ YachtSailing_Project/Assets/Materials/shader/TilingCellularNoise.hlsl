#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED

int2 tiling_position(float2 st, float scale)
{
	float eps = 0.1;
	int2 sig = step(0.0, st);
	int2 p = fmod(floor(st), scale) + eps * sign(st);
	p = p * sig + (scale + p) * sign(-p) * (1 - sig);

	return p;
}

float2 rand2d(float2 st, int seed)
{
	float2 s = float2(dot(st, float2(127.1, 311.7)) + seed, dot(st, float2(269.5, 183.3)) + seed);
	return frac(sin(s) * 43758.5453123);
}

float Tiling_CellularNoise(float2 st, int scale, int seed)
{
	float2 f_st = frac(st);

	float min_dist = 1.0;
	float2 min_p;
	for (int j = -1; j <= 1; j++)
	{
		for (int k = -1; k <= 1; k++)
		{
			float2 n = float2(j, k);
			float2 p = rand2d(tiling_position(st + n, scale), seed);
			float dist = distance(f_st, p + n);
			if (dist < min_dist)
			{
				min_dist = dist;
				min_p = p;
			}
		}
	}
	return min_dist;
}

void TilingCellularNoise_float(float2 UV, int Scale, int Seed, float2 Offset, out float Out)
{
	UV = UV * Scale + Offset;

	float result = Tiling_CellularNoise(UV, Scale, Seed);

	Out = result;
}

#endif