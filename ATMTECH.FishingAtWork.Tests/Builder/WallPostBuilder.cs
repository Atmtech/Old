using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class WallPostBuilder
    {
        public static WallPost Create()
        {
            return new WallPost();
        }
        public static WallPost WithPost(this WallPost wallPost, string post)
        {
            wallPost.Post = post;
            return wallPost;
        }

        public static WallPost WithPlayer(this WallPost wallPost, Player player)
        {
            wallPost.Player = player;
            return wallPost;
        }
     
        public static WallPost CreateValid()
        {
            return new WallPost().WithPost("Post").WithPlayer(PlayerBuilder.CreateValid());
        }
    }
}
