#include <stdio.h>
int main(){
    int n,m,M[n][m],j,i,suma,may;
    printf("n,m");
    scanf("%i,%i",&n,&m);
    for(j=0;j<=n;j+1){
        if(j==0){
            may=M[i][j];
        }else if(M[i][j]>M[i][j-1]){
            may=M[i][j];
        }
        suma=may+suma;
    }
    printf("%i",&suma);
}