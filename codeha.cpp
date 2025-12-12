#include <bits/stdc++.h>
using namespace std;

int main(){
    string s;  
    cin >> s; 

    int score = 0;

    vector<pair<string,int>> patterns = {
        {"ha",1},
        {"boooo",-1},
        {"bravo",3}
    };

    for (auto &p : patterns){
        string &sub = p.first;
        int val = p.second;
        size_t pos = s.find(sub);
        while (pos != string::npos){
            score += val;
            pos = s.find(sub, pos + 1);
        }
    }

    cout << score << endl; 
    return 0;
}