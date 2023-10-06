insert into Roles values ('c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf','Admin',1)
insert into Roles values ('1001d4d6-ebae-4c35-8332-7d2b1a60fa44','User',1)

insert into Colors values('5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a',N'Trắng',1)
insert into Colors values('79b80749-b18b-4875-9f27-75f5d6ad4f93',N'Đen',1)
insert into Colors values('7f697aeb-42fd-4c32-bc13-ed11f88ab74a',N'Xám',1)
insert into Colors values('0ed1e297-5644-4bc7-9486-cf69bf7994a2',N'Kem',1)

insert into Sizes values('d1e0eec9-81a1-4dd8-a70f-469f1d0fe021','S',1)
insert into Sizes values('6778ef5b-5901-46e2-9ca9-7bea36e4ff9b','M',1)
insert into Sizes values('c1377708-db38-440b-833d-0e99259e50bb','L',1)
insert into Sizes values('70591428-7358-4c0d-a7b7-4a30f1236f15','XL',1)


insert into Categories values('de92d4b4-ba16-43d5-b7c3-fad74c97fe22',N'Áo thun',1)
insert into Categories values('d6d95297-754f-4428-9504-21cf9a390eb5',N'Áo Hoodie',1)
insert into Categories values('a6b68fb7-e600-46db-b15f-2fe4e09b72a4',N'Áo Sweater',1)
insert into Categories values('b0349aa9-3622-445c-9b43-ddba60038279',N'Áo Polo',1)


insert into Users values('861a5ad4-5890-46bf-95a5-fc85ae80367d',N'Nguyễn',N'Thắng','thang','123','thang@gmail.com','0367180646',1,1,N'Số nhà 1',N'Bắc Từ Liêm','c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf',N'Hà Nội',N'Minh Khai')
insert into Users values('3e1ef0a0-9978-4a48-ad14-c808819ec723',N'Nguyễn',N'Tuấn','tuan','123','tuan@gmail.com','012345689',1,1,N'Số nhà 2',N'Hoài Đức','1001d4d6-ebae-4c35-8332-7d2b1a60fa44',N'Hà Nội',N'Phùng')

insert into Carts values('861a5ad4-5890-46bf-95a5-fc85ae80367d',N'',1)
insert into Carts values('3e1ef0a0-9978-4a48-ad14-c808819ec723',N'',1)


insert into Promotions values('26b35f5d-3604-4011-945b-353bc21d8ed0','KM1','KMT10','50',50,'2023-10-4','2023-12-30',N'',N'',1)
insert into Promotions values('e539888f-bd53-44e2-afb1-08f4f448edb5','KM2','THANHVIENMOI','50',50,'2023-10-4','2024-12-30',N'',N'',1)

insert into Products values('a3ce510a-074a-4a51-b590-1bd0eeaa064d',N'Áo thun Outerity Meowment Tee','de92d4b4-ba16-43d5-b7c3-fad74c97fe22',1)
insert into Products values('3b838f25-291c-410d-8dac-05e7b79afcb1',N'Áo Polo Outerity Polo Meowment','b0349aa9-3622-445c-9b43-ddba60038279',1)

insert into ProductItems values('adf8e940-28df-47e1-8bf2-4e7ec92ec784','a3ce510a-074a-4a51-b590-1bd0eeaa064d','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('6880b307-d5da-4c93-b74b-73bcad8702e9','a3ce510a-074a-4a51-b590-1bd0eeaa064d','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('dd634415-4758-4e01-9401-20e148681866','a3ce510a-074a-4a51-b590-1bd0eeaa064d','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('96876713-8c3a-4db1-a72c-5220c715b81b','a3ce510a-074a-4a51-b590-1bd0eeaa064d','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)
	

insert into ProductItems values('48d91834-0b5f-45f0-9202-206e47c55759','a3ce510a-074a-4a51-b590-1bd0eeaa064d','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('218daa80-ee92-4ffb-85c8-0ed02f99367f','a3ce510a-074a-4a51-b590-1bd0eeaa064d','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('9a1a7cc2-455c-425d-acba-b0ce54fdb892','a3ce510a-074a-4a51-b590-1bd0eeaa064d','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('a2f8f40e-e3eb-41e8-b1cc-35b3b0c6bbec','a3ce510a-074a-4a51-b590-1bd0eeaa064d','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)


insert into ProductItems values('9210148d-9ffc-4198-87c9-7f37bc97de45','a3ce510a-074a-4a51-b590-1bd0eeaa064d','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('1b7bf899-689d-4dbb-9b14-d383b75214a2','a3ce510a-074a-4a51-b590-1bd0eeaa064d','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('a9137841-c184-41b0-bb79-e81ecdcd861e','a3ce510a-074a-4a51-b590-1bd0eeaa064d','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('9b4f1171-50e2-4684-baba-d4975e69e2f6','a3ce510a-074a-4a51-b590-1bd0eeaa064d','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)


insert into ProductItems values('de35f925-bb1f-4de7-9146-2b61dba050a3','a3ce510a-074a-4a51-b590-1bd0eeaa064d','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('71efdb82-1d37-4bd0-96c0-2cf2f857e25d','a3ce510a-074a-4a51-b590-1bd0eeaa064d','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('e8dbb0cd-c7c1-4b83-a725-5d5bbecb8132','a3ce510a-074a-4a51-b590-1bd0eeaa064d','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('d9079060-cfe1-4531-9af1-38db9b43e13b','a3ce510a-074a-4a51-b590-1bd0eeaa064d','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)



insert into ProductItems values('f1a2ddaf-9905-48c7-82d9-f4f8f02d43b1','3b838f25-291c-410d-8dac-05e7b79afcb1','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('59ca3315-9ed2-43de-a0ab-74f5300df43c','3b838f25-291c-410d-8dac-05e7b79afcb1','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('01aad59c-9e6e-43bf-bcaf-b0998b32ed25','3b838f25-291c-410d-8dac-05e7b79afcb1','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('2b51c437-0584-400c-8b1b-ee0690e330dd','3b838f25-291c-410d-8dac-05e7b79afcb1','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)
	

insert into ProductItems values('953560d4-719c-45e6-b14c-cd6b61d5d65b','3b838f25-291c-410d-8dac-05e7b79afcb1','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('56d26e67-36ca-4f0f-b411-e96573d76b44','3b838f25-291c-410d-8dac-05e7b79afcb1','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('fba5eca5-52b1-4bf6-a0d5-e9fdca27d800','3b838f25-291c-410d-8dac-05e7b79afcb1','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('f732ccfa-3dd2-49e1-a522-c179f1589c44','3b838f25-291c-410d-8dac-05e7b79afcb1','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)


insert into ProductItems values('6ca953a7-1d2e-40d6-b6c9-ca3223ae7b41','3b838f25-291c-410d-8dac-05e7b79afcb1','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('b6fea6c5-fea1-49c7-80bb-4e703c91a905','3b838f25-291c-410d-8dac-05e7b79afcb1','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('2a447516-9558-47b8-98b1-a9ad3ba4a2aa','3b838f25-291c-410d-8dac-05e7b79afcb1','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('cde3febb-aa0e-4051-9b7f-3cc408dac9f9','3b838f25-291c-410d-8dac-05e7b79afcb1','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)


insert into ProductItems values('bae06b8e-457c-4404-9245-e78624917619','3b838f25-291c-410d-8dac-05e7b79afcb1','5bc1a17e-a2c1-42bf-8de5-31cf2a0ee53a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('68fb5967-c69d-4777-bb3b-840da440e852','3b838f25-291c-410d-8dac-05e7b79afcb1','79b80749-b18b-4875-9f27-75f5d6ad4f93','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('77f4be97-62df-4c5b-a9b1-7f690a1db3e1','3b838f25-291c-410d-8dac-05e7b79afcb1','7f697aeb-42fd-4c32-bc13-ed11f88ab74a','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)	
insert into ProductItems values('dd5a54ef-375a-41ed-b439-10b9a4b28d7e','3b838f25-291c-410d-8dac-05e7b79afcb1','0ed1e297-5644-4bc7-9486-cf69bf7994a2','d1e0eec9-81a1-4dd8-a70f-469f1d0fe021',1000,150000,250000,1)


	


insert into PromotionsItem values('21e18eec-2474-417a-81a7-723924559bae','26b35f5d-3604-4011-945b-353bc21d8ed0','de35f925-bb1f-4de7-9146-2b61dba050a3',1)
insert into PromotionsItem values('6a2d938e-e007-4421-bcb9-c7882ce2253f','26b35f5d-3604-4011-945b-353bc21d8ed0','cde3febb-aa0e-4051-9b7f-3cc408dac9f9',1)
insert into PromotionsItem values('f000ee9e-86b5-4224-af3f-56aee0076f61','e539888f-bd53-44e2-afb1-08f4f448edb5','9210148d-9ffc-4198-87c9-7f37bc97de45',1)
insert into PromotionsItem values('8b0ab080-d4a1-41ab-b744-c4fdcb707d3d','e539888f-bd53-44e2-afb1-08f4f448edb5','6880b307-d5da-4c93-b74b-73bcad8702e9',1)



insert into Images values('913a262c-a5bb-45a4-848b-d55b8e5d4978',N'Ảnh 1','','6880b307-d5da-4c93-b74b-73bcad8702e9',1)
insert into Images values('923f1c8e-9e7b-46f9-a4dd-9b34e02574cc',N'Ảnh 2','','9210148d-9ffc-4198-87c9-7f37bc97de45',1)

insert into CartItems values('fb97b1d4-9c5c-466a-b783-66797173d916','861a5ad4-5890-46bf-95a5-fc85ae80367d','b6fea6c5-fea1-49c7-80bb-4e703c91a905',1,300000,2)
insert into CartItems values('6ef6385e-dd07-4450-b269-000eabcae6ab','861a5ad4-5890-46bf-95a5-fc85ae80367d','56d26e67-36ca-4f0f-b411-e96573d76b44',1,300000,5)
insert into CartItems values('85087654-1a44-43ae-83d1-0dd7675404d6','3e1ef0a0-9978-4a48-ad14-c808819ec723','01aad59c-9e6e-43bf-bcaf-b0998b32ed25',1,300000,1)
insert into CartItems values('d0d7d2e3-cabf-4185-b191-f09c85f24466','3e1ef0a0-9978-4a48-ad14-c808819ec723','dd5a54ef-375a-41ed-b439-10b9a4b28d7e',1,300000,5)


insert into Bills values('5f7bb1e5-d805-4cce-b761-ff1249daa10e','3e1ef0a0-9978-4a48-ad14-c808819ec723','2023-10-1',300000,N'',1,N'Số nhà 1',N'Hoài Đức','1234567899',N'Nguyễn Duy Tuấn',N'Hà Nội','Acf')
insert into Bills values('09c05b32-372d-46e1-bbc9-1109f4965b40','3e1ef0a0-9978-4a48-ad14-c808819ec723','2023-9-23',300000,N'',1,N'Số nhà 2',N'Bắc Từ Liêm','1234567899',N'Nguyễn Hưng Kiên',N'Nam Định',N'Á')

insert into BillItems values('347a3d4d-a70b-4c7d-bc2b-3127b977dc39','5f7bb1e5-d805-4cce-b761-ff1249daa10e','96876713-8c3a-4db1-a72c-5220c715b81b',1,300000,1)
insert into BillItems values('16f569e9-8162-4d5a-80d1-685a70d65c1e','5f7bb1e5-d805-4cce-b761-ff1249daa10e','a2f8f40e-e3eb-41e8-b1cc-35b3b0c6bbec',1,300000,1)

