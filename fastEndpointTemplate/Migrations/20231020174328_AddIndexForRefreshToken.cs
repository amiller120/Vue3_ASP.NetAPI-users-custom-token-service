using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fastEndpointTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId_Token_ExpiryDate",
                table: "RefreshTokens",
                columns: new[] { "UserId", "Token", "ExpiryDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId_Token_ExpiryDate",
                table: "RefreshTokens");
        }
    }
}
