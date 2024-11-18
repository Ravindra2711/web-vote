https://tests.mettl.com/test-window-pi?key=apogi%2BExICpAZmt5DwUPW6ppBKVW0SpU2GQOBtSrod5tAuCium%2BarSPzZbUmcRW%2F

#include <iostream>
#include <vector>
#include <string>
#include <climits>
using namespace std;

int getDir(string s) {
    if(s == "up") return 0;
    if(s == "down") return 1;
    if(s == "left") return 2;
    return 3;
}

int solve(int f1, int f2, int pos, vector<int>& seq, vector<vector<vector<int>>>& cache) {
    if(pos >= (int)seq.size()) 
        return 0;
    
    if(cache[f1][f2][pos] != -1)
        return cache[f1][f2][pos];

    int next = seq[pos];
    int res = 999999;
    
    if(f1 == next)
        res = solve(f1, f2, pos + 1, seq, cache);
    if(f2 == next)
        res = min(res, solve(f1, f2, pos + 1, seq, cache));
    
    
    res = min(res, 1 + solve(next, f2, pos + 1, seq, cache));
    res = min(res, 1 + solve(f1, next, pos + 1, seq, cache));
    
    cache[f1][f2][pos] = res;
    return res;
}

int main() {
    int n;
    cin >> n;
    
    
    string tmp;
    vector<string> inp;
    while(n--) {
        cin >> tmp;
        inp.push_back(tmp);
    }
    
    
    vector<int> moves;
    for(auto x : inp)
        moves.push_back(getDir(x));
    
    
    vector<vector<vector<int>>> memo(4, vector<vector<int>>(4, vector<int>(inp.size(), -1)));
    
    int ans = 999999;
    
    for(int i = 0; i < 4; i++)
        for(int j = 0; j < 4; j++)
            if(i != j)  
                ans = min(ans, solve(i, j, 0, moves, memo));
    
    cout << ans;
    cout.flush();
    return 0;
}
