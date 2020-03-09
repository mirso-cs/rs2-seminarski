using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Source.net.infrastructure.Enums;
using Source.net.infrastructure.Views;

namespace Source.net.desktop.Shared
{
    public class StatisticsHttpClient: HttpClient
    {
        public StatisticsHttpClient(string path): base(path)
        {

        }

        public async Task<TotalCount> GetTotalCountForType(string type)
        {
            return await getPath().AppendPathSegment(type).GetJsonAsync<TotalCount>();
        }

        public async Task<IEnumerable<ChartItem>> GetChartForType(string type)
        {
            return await getPath().AppendPathSegment("chart/"+type)
                .GetJsonAsync<IEnumerable<ChartItem>>();
        }

        public async Task<AverageOf> GetAverageUserRating(int id)
        {
            return await getPath().AppendPathSegment("user/" + id)
                .GetJsonAsync<AverageOf>();
        }
        
        public async Task<List<PostView>> GetUserBestPosts(int id)
        {
            return await getPath().AppendPathSegment("user/" + id + "/posts")
                .GetJsonAsync<List<PostView>>();
        }
    }
}
