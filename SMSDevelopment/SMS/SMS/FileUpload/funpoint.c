#include<stdio.h>
/*void change(int x,int y);
void main()
{
		int a,b;

		a=10;
		b=20;
		change(a,b);
		printf("\n%d%d",a,b);
	  //	return 0;

}
void change(int x,int y)
{
	  printf("\n%d%d",x,y);
	  ++(x);
	  ++(y);
	  printf("\n%d%d",x,y);

}  */

/*void change(int *x,int *y);
void main()
{
		int a,b;

		a=10;
		b=20;
		change(&a,&b);
		printf("\n%d%d",a,b);
	  //	return 0;

}
void change(int x,int y)
{
	  printf("\n%d%d",*x,*y);
	  ++(*x);
	  ++(*y);
	  printf("\n%d%d",*x,*y);

} */

void change(int x,int *y);
void main()
{
		int a,b;

		a=10;
		b=20;
		change(a,&b);
		printf("\n%d%d",a,b);
	  //	return 0;

}
void change(int x,int *y)
{
	  printf("\n%d%d",x,*y);
	  ++(x);
	  ++(*y);
	  printf("\n%d%d",x,*y);

}


