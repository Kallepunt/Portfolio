﻿using System.Runtime.InteropServices;
using Portfolio.Pages.WhackMe.Game.Models;
using SqliteWasmHelper;

namespace Portfolio.Pages.WhackMe.Game.Services
{
	public class WhackMeHighScoreSerice
	{
		private readonly ISqliteWasmDbContextFactory<HighScoreContext> _dbFactory;
		//private List<Highscore> Highscores = new();

		public WhackMeHighScoreSerice(ISqliteWasmDbContextFactory<HighScoreContext> dbFactory)
		{
			_dbFactory = dbFactory;
		}

		public async Task<List<Highscore>> GetHighScoresAsync()
		{
			using var ctx = await _dbFactory.CreateDbContextAsync();

			if (!ctx.Highscores.Any())
			{
				ctx.Highscores.Add(new Highscore()
				{
				
					Name = "Oskar",
					Score = 25,
				
				}); ;

			    ctx.Highscores.Add(new Highscore()
				{
				
					Name = "Chrille",
					Score = 31,

				}); ;
			}

			//await ctx.SaveChangesAsync();
			return ctx.Highscores.ToList();
		}

		public async Task AddHighScore(Highscore s)
		{
          
            using var ctx = await _dbFactory.CreateDbContextAsync();

			var score = new Highscore()
			{
				Name = s.Name,
				Score = s.Score,
			};


			ctx.Highscores.Add(s);
			await ctx.SaveChangesAsync();

		}


	}
}
