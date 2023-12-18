#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

int main(int argc, char *argv[])
{
	char *text = "hello, world\n";
	char *template = "/some/path/mytmp_XXXXXX";
	int template_len = strlen(template);

	char *path = malloc(template_len + 1);
	if (path == NULL) {
		perror("malloc");
		exit(1);
	}

	strncpy(path, template, template_len);
	path[template_len] = 0;

	int fd = mkstemp(path);
	free(path);

	if (fd == -1) {
		perror("msktemp");
		exit(1);
	}

	write(fd, text, strlen(text));
	close(fd);
	exit(0);
}

