#include <stdio.h>
#include <string.h>

int main(int argc, char** argv)
{
    int open_parentheses = 0;

    char* input_string = argv[1];

    for (int i = 0; i < strlen(input_string); i++)
    {
	char c = input_string[i];
	if (c == '(')
	{
	    open_parentheses++;
	}
	else if (c == ')' && open_parentheses > 0)
	{
	    open_parentheses--;
	}
	else if (c == ')')
	{
	    printf("Not nested correctly\n");
	    return 1;
	}
    }

    if (open_parentheses > 0)
    {
	printf("Not nested correctly\n");
	return 1;
    }
    else
    {
	printf("Nested correctly\n");
	return 0;
    }
}
