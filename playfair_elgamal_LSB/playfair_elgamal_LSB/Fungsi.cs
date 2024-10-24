using System;

namespace playfair_elgamal_LSB
{
	public class Fungsi
	{
		public static Random r = new Random();
		
		public static int modexp(int x, int y, int n)
		{
			int z = 1;
    		for (int i = 0; i < y ; i++){
          	z = (x * z)  % n;
    		}
			return z;
		}
		
		public static int modexp(int x, int z, int y, int n)
		{
			for (int i = 0; i < y ; i++){
          	z = (x * z)  % n;
    		}
			return z;
		}
		
		public static int lehmann(int n) 
		{ 
		  	int t = 3;
		    int a = r.Next(n - 3) + 2; 
		  	int e = (n - 1) / 2; 
		  	while(t > 0) 
		    {
		  		int result = modexp(a,e,n);
		  		if (((result % n) == 1 || (result % n) == (n - 1)) && n % 2 == 1)
		        {
		      		a = r.Next(n - 3) + 2;
		            t -= 1;
		        }
		      	else
		            return lehmann(r.Next(257,1000)); 
		    } 
		    return n; 
		}
	}
}
