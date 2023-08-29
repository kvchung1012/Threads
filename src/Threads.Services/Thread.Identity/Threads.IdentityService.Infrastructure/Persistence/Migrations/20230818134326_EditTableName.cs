using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Threads.IdentityService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPermission_ApplicationPermission_ParentId",
                table: "ApplicationPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermission_ApplicationPermission_ApplicationPermissionId",
                table: "ApplicationRolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermission_ApplicationPermission_PermissionId",
                table: "ApplicationRolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermission_AspNetRoles_ApplicationRoleId",
                table: "ApplicationRolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermission_AspNetRoles_RoleId",
                table: "ApplicationRolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRolePermission",
                table: "ApplicationRolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationPermission",
                table: "ApplicationPermission");

            migrationBuilder.RenameTable(
                name: "ApplicationRolePermission",
                newName: "ApplicationRolePermissions");

            migrationBuilder.RenameTable(
                name: "ApplicationPermission",
                newName: "ApplicationPermissions");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermission_RoleId",
                table: "ApplicationRolePermissions",
                newName: "IX_ApplicationRolePermissions_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermission_PermissionId",
                table: "ApplicationRolePermissions",
                newName: "IX_ApplicationRolePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermission_ApplicationRoleId",
                table: "ApplicationRolePermissions",
                newName: "IX_ApplicationRolePermissions_ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermission_ApplicationPermissionId",
                table: "ApplicationRolePermissions",
                newName: "IX_ApplicationRolePermissions_ApplicationPermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationPermission_ParentId",
                table: "ApplicationPermissions",
                newName: "IX_ApplicationPermissions_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRolePermissions",
                table: "ApplicationRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationPermissions",
                table: "ApplicationPermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPermissions_ApplicationPermissions_ParentId",
                table: "ApplicationPermissions",
                column: "ParentId",
                principalTable: "ApplicationPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermissions_ApplicationPermissions_ApplicationPermissionId",
                table: "ApplicationRolePermissions",
                column: "ApplicationPermissionId",
                principalTable: "ApplicationPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermissions_ApplicationPermissions_PermissionId",
                table: "ApplicationRolePermissions",
                column: "PermissionId",
                principalTable: "ApplicationPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermissions_AspNetRoles_ApplicationRoleId",
                table: "ApplicationRolePermissions",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermissions_AspNetRoles_RoleId",
                table: "ApplicationRolePermissions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPermissions_ApplicationPermissions_ParentId",
                table: "ApplicationPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermissions_ApplicationPermissions_ApplicationPermissionId",
                table: "ApplicationRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermissions_ApplicationPermissions_PermissionId",
                table: "ApplicationRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermissions_AspNetRoles_ApplicationRoleId",
                table: "ApplicationRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRolePermissions_AspNetRoles_RoleId",
                table: "ApplicationRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRolePermissions",
                table: "ApplicationRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationPermissions",
                table: "ApplicationPermissions");

            migrationBuilder.RenameTable(
                name: "ApplicationRolePermissions",
                newName: "ApplicationRolePermission");

            migrationBuilder.RenameTable(
                name: "ApplicationPermissions",
                newName: "ApplicationPermission");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermissions_RoleId",
                table: "ApplicationRolePermission",
                newName: "IX_ApplicationRolePermission_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermissions_PermissionId",
                table: "ApplicationRolePermission",
                newName: "IX_ApplicationRolePermission_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermissions_ApplicationRoleId",
                table: "ApplicationRolePermission",
                newName: "IX_ApplicationRolePermission_ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRolePermissions_ApplicationPermissionId",
                table: "ApplicationRolePermission",
                newName: "IX_ApplicationRolePermission_ApplicationPermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationPermissions_ParentId",
                table: "ApplicationPermission",
                newName: "IX_ApplicationPermission_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRolePermission",
                table: "ApplicationRolePermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationPermission",
                table: "ApplicationPermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPermission_ApplicationPermission_ParentId",
                table: "ApplicationPermission",
                column: "ParentId",
                principalTable: "ApplicationPermission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermission_ApplicationPermission_ApplicationPermissionId",
                table: "ApplicationRolePermission",
                column: "ApplicationPermissionId",
                principalTable: "ApplicationPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermission_ApplicationPermission_PermissionId",
                table: "ApplicationRolePermission",
                column: "PermissionId",
                principalTable: "ApplicationPermission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermission_AspNetRoles_ApplicationRoleId",
                table: "ApplicationRolePermission",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRolePermission_AspNetRoles_RoleId",
                table: "ApplicationRolePermission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
