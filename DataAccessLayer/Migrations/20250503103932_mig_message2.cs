using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_message2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_ReceiverID",
                table: "Message2");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_SenderID",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message2",
                newName: "Messages2s");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_SenderID",
                table: "Messages2s",
                newName: "IX_Messages2s_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_ReceiverID",
                table: "Messages2s",
                newName: "IX_Messages2s_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages2s",
                table: "Messages2s",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2s_Writers_ReceiverID",
                table: "Messages2s",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2s_Writers_SenderID",
                table: "Messages2s",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages2s_Writers_ReceiverID",
                table: "Messages2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2s_Writers_SenderID",
                table: "Messages2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages2s",
                table: "Messages2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages2s",
                newName: "Message2");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages2s_SenderID",
                table: "Message2",
                newName: "IX_Message2_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages2s_ReceiverID",
                table: "Message2",
                newName: "IX_Message2_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2",
                table: "Message2",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_ReceiverID",
                table: "Message2",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_SenderID",
                table: "Message2",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }
    }
}
