<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
			<body>
				<h1 style="text-align: center;">Student List</h1>

				<xsl:for-each select="Students/Student">
					<!--Sort by ID number-->
					<!--TODO: see if you want to change the sorting-->
					<xsl:sort select="ID"/>
					<div style="border: 1px dashed;">
						<ul>
							<li>
								<xsl:for-each select="Name">
									<label>Name: </label>
									<label>
										<xsl:value-of select="First"/>&#160;
									</label>
									<label>
										<xsl:value-of select="Last"/>
									</label>
								</xsl:for-each>
							</li>
							<li>
								<label>ID: </label>
								<label><xsl:value-of select="ID"/></label>
							</li>
							<li>
								<label>Barrett: </label>
								<label><xsl:value-of select="@Barrett"/></label>
							</li>
							<li>
								<label>Meals Left: </label>
								<label><xsl:value-of select="Meals"/></label>
							</li>
							<li>
								<label>M and G: $</label>
								<label><xsl:value-of select="MGDollars"/></label>
							</li>
							<li>
								<label>Guest Passes: </label>
								<label><xsl:value-of select="GuestPasses"/></label>
							</li>
						</ul>
					</div>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>