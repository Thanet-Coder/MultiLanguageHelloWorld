
#include <stdio.h>

__declspec(dllexport)
void print_message(const char* message)
{
    printf("C Output: %s\n", message);
    fflush(stdout);
}
