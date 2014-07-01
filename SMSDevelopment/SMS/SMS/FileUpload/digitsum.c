#include<stdio.h>
 void main()
 {
	  int first,last,n,s=0,t;
	  printf("Enter a digit:");
	  scanf("\n%d",&n);

	  last=n%10;
     printf("last is %d\n",last);

	  while(n>0)
	  {
		s=n%10;

	  first=s;
	  n=n/10;

	  }
	  printf("first is %d\n",first);


	  t=first+last;
	  printf("Sum Of first And last :%d",t);
  }


