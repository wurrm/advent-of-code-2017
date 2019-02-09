// Q: Write a function to determine whether two integers are equal without using any comparison operators.

#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

bool bitEquality(int, int);

int main(int argc, char** argv)
{
    int a = atoi(argv[1]), b = atoi(argv[2]);

    if (bitEquality(a, b))
	printf("%i and %i are equal.\n", a, b);
    else
	printf("%i and %i are not equal.\n", a, b);
}

bool bitEquality(int a, int b)
{
    int c = a ^ b;
    if (c)
	return false;
    else
	return true;
}
