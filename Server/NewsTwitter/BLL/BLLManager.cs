using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoeMobile.BLL;

namespace WoeMobile.BLL
{
    public class BLLManager
    {
        public static ManagerBiz manager = new ManagerBiz();
        public static ArtistsManager artists = new ArtistsManager();
        public static AlbumsManager albums = new AlbumsManager();
        public static EuserManager euser = new EuserManager();
        public static Euser_detailManager euser_detail = new Euser_detailManager();
        public static Friend_listManager friend_list = new Friend_listManager();
        public static Friend_list_userManager friend_list_user = new Friend_list_userManager();
        public static ImagesManager images = new ImagesManager();
        public static InformationManager information = new InformationManager();
        public static ItemManager item = new ItemManager();
        public static LocationsManager locations = new LocationsManager();
        public static LogmManager logm = new LogmManager();
        public static Long_twitterManager long_twitter = new Long_twitterManager();
        public static Music_srcManager music_src = new Music_srcManager();
        public static MusicsManager musics = new MusicsManager();
        public static NewsManager news = new NewsManager();


        public static News_commentManager news_comment = new News_commentManager();
        public static OrganizationManager organization = new OrganizationManager();
        public static RightBiz rights = new RightBiz();

        public static RoleManager role = new RoleManager();
        public static RolerightreltionManager rolerightreltion = new RolerightreltionManager();
        public static TemplateManager template = new TemplateManager();
        public static TracesManager traces = new TracesManager();
        public static Tw_typesManager tw_types = new Tw_typesManager();
        public static TwitterManager twitter = new TwitterManager();
        public static Twitter_commentManager twitter_comment = new Twitter_commentManager();
        public static Twitter_loveManager twitter_love = new Twitter_loveManager();

    }
}
