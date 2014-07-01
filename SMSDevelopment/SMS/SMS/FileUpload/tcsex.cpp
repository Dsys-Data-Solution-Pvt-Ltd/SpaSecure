#include<iostream.h>
#include<conio.h>

class abc
{
	private:
		int x,y;
	public:
		abc()
		{
			x=0;
			y=0;
		}
		void set(int a,int b)
		{
			x=a;
			y=b;
		}
		int sum()
		{
			int c;
			c=x+y;
			return c;
		}
};

void main()
{
	abc a;
	a.set(9,17);
	int l=a.sum();
	cout<<"the sum is:"<<l<<endl;
	//delete this;
}