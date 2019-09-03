// Q: Write a function to determine whether two integers are equal without using any comparison operators.

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int a = atoi(argv[1]), b = atoi(argv[2]);

    printf("%i and %i are %sequal.\n", a, b, (a ^ b) ? "not " : "");
}
