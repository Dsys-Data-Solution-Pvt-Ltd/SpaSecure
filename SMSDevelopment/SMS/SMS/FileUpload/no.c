#include<stdio.h>
#include<conio.h>
void main()
{
	  //For first Loop
	  /*for(int i=5;i>=0;i--)
	  {
			for(int j=5;j>i;j--)
			{
				  printf("%d",j);
			}
			printf("\n");

	  }*/

	  for(int i=1;i<=5;i++)
	  {
		for(int j=i;j<=5;j++)
		{
			printf("*");
		}
		printf("\n");
	  }
	  //printf("\n");

	  for(int k=1;k<=5;k++)
	  {
		for(int t=1;t<=k;t++)
		{
			printf("*");
		}
		printf("\n");
	  }
	  getch();


}